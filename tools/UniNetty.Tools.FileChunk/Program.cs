using System;
using System.IO;
using System.Linq;

class Program
{
    static int Main(string[] args)
    {
        string driveLetter = $"{args[1]}:\\";
        long totalSize = GetFreeSpace(driveLetter);
        int blockSize = 1 * 1024 * 1024 * 100;
        int numBlocks = (int)(totalSize / blockSize);

        Console.WriteLine($"free size : {totalSize / (1024 * 1024)}MB");
        
        string input = Console.ReadLine();
        if (input?.Trim().ToLower() != "start")
            return -1;

        var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 70 };
        Parallel.For(0, numBlocks, parallelOptions, i =>
        {
            string tempFilePath = Path.Combine(driveLetter, $"temp_{Path.GetRandomFileName()}.bin");
            
            byte[] buffer = new byte[blockSize];
            Random random = new Random();
            random.NextBytes(buffer);

            using var fs = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
            fs.Write(buffer, 0, buffer.Length);

            Console.WriteLine($"create file : {tempFilePath}");
        });

        Console.WriteLine("Done");

        return 0;
    }

    static long GetFreeSpace(string driveLetter)
    {
        DriveInfo driveInfo = new DriveInfo(driveLetter);
        return driveInfo.AvailableFreeSpace;
    }
}