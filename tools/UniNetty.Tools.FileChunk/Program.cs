using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static int Main(string[] args)
    {
        string driveLetter = $"{args[0]}:\\";
        long totalSize = GetFreeSpace(driveLetter);
        int blockSize = 1 * 1024 * 1024 * 100;
        int numBlocks = (int)(totalSize / blockSize);

        Console.WriteLine($"free size : {totalSize / (1024 * 1024)}MB");
        Console.WriteLine("If you really want to start, type 'start'.");

        string input = Console.ReadLine();
        if (input?.Trim().ToLower() != "start")
            return -1;

        byte[] buffer = new byte[blockSize];

        var cancelBag = new ConcurrentBag<long>();
        RegisterCancel(cancelBag);


        for (int i = 0; i < numBlocks; ++i)
        {
            if (!cancelBag.IsEmpty)
                break;

            Random random = new Random();
            random.NextBytes(buffer);

            string tempFilePath = Path.Combine(driveLetter, $"temp_{Path.GetRandomFileName()}.bin");

            Console.WriteLine($"creating file : {tempFilePath}");

            using var fs = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
            fs.Write(buffer, 0, buffer.Length);

            Console.WriteLine($"created file : {tempFilePath}");
        }

        Console.WriteLine("Done");

        return 0;
    }

    static long GetFreeSpace(string driveLetter)
    {
        DriveInfo driveInfo = new DriveInfo(driveLetter);
        return driveInfo.AvailableFreeSpace;
    }

    static void RegisterCancel(ConcurrentBag<long> bag)
    {
        ConsoleCancelEventHandler handler = (sender, e) =>
        {
            if (ConsoleSpecialKey.ControlC == e.SpecialKey || ConsoleSpecialKey.ControlBreak == e.SpecialKey)
            {
                e.Cancel = true;
                bag.Add(DateTime.UtcNow.Ticks);
            }
            else
            {
                // 코드 스트림이 여기까지 도달 할 수 있는가?
                e.Cancel = false;
            }
        };

        Console.CancelKeyPress += handler;
    }
}