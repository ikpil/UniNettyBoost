using System;
using System.IO;
using System.Numerics;
using ImGuiNET;
using Serilog;
using UniNetty.Examples.DemoSupports;

namespace UniNetty.Examples.Demo.UI;

public class ExamplesView : IView
{
    private static readonly ILogger Logger = Log.ForContext<UniNettyDemo>();

    private readonly Canvas _canvas;
    private readonly ExamplesViewModel _vm;

    public ExamplesView(Canvas canvas)
    {
        _canvas = canvas;
        _vm = new ExamplesViewModel(canvas.Context);
    }

    public void Draw(double dt)
    {
        //ImGui.ShowDemoWindow();

        float menuWidth = 260.0f;
        float offsetY = 50.0f;
        ImGui.SetNextWindowPos(new Vector2(_canvas.Size.X - menuWidth - 10.0f, offsetY));
        ImGui.SetNextWindowSize(new Vector2(menuWidth, _canvas.Size.Y - offsetY - 10.0f));

        ImGui.Begin("Examples", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse);

        // size reset
        var rectSize = ImGui.GetItemRectSize();
        if (32 >= rectSize.X && 32 >= rectSize.Y)
        {
            int width = 310;
            var posX = _canvas.Size.X - width;
            //ImGui.SetWindowPos(new Vector2(posX, 0));
            ImGui.SetWindowSize(new Vector2(width, _canvas.Size.Y - 60));
        }

        foreach (var example in _vm.Examples)
        {
            if (null == example)
                continue;

            var showSettings = ImGui.TreeNodeEx(example.Setting.Example.Name, ImGuiTreeNodeFlags.Bullet | ImGuiTreeNodeFlags.SpanFullWidth);
            if (showSettings)
            {
                int port = example.Setting.Port;
                if (ImGui.InputInt(" " + example.Setting.Example.Name + " Port", ref port)) ;
                {
                    example.Setting.SetPort(port);
                }

                // use size
                if (0 != example.Setting.Size)
                {
                    int size = example.Setting.Size;
                    if (ImGui.InputInt(" " + example.Setting.Example.Name + " Size", ref size))
                    {
                        example.Setting.SetSize(size);
                    }
                }

                var btnServer = example.IsRunningServer ? "Stop Server" : "Run Server";
                if (ImGui.Button(example.Setting.Example.Name + " " + btnServer))
                {
                    example.ToggleServer();
                }

                var btnClient = example.IsRunningClient ? "Stop Client" : "Run Client";
                if (ImGui.Button(example.Setting.Example.Name + " " + btnClient))
                {
                    example.ToggleClient();
                }


                ImGui.TreePop();
            }

            ImGui.Separator(); // 구분선
        }

        ImGui.End();
    }

    public void Update(double dt)
    {
    }
}