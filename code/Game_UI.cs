
using Godot;
using ImGuiGodot;
using ImGuiNET;
using static System.Net.Mime.MediaTypeNames;

namespace Cgj_2024.code;

public partial class Game
{


    void EnterTree_UI()
    {
    }


    public override void _Process(double delta)
    {
        ImGui.Begin("test");
        Text("测试！", Colors.Cyan);
        Text(
            ("青", Colors.Cyan),
            ("橙", Colors.Orange),
            ("黄", Colors.Yellow),
            ("绿", Colors.Green),
            ("蓝", Colors.Blue),
            ("靛", Colors.DarkBlue),
            ("紫", Colors.Purple)
            );
        ImGui.End();
        ImGuiGD.Scale = 4;
    }


    public static void Text(string text, Color color)
    {
        ImGui.PushStyleColor(ImGuiCol.Text, color.ToVector4());
        ImGui.Text(text);
        ImGui.PopStyleColor();
    }

    public static void Text(params (string, Color)[] texts)
    {
        for (int i = 0; i < texts.Length; ++i) 
        {
            if (i > 0)
            {
                ImGui.SameLine();
            }
            var text = texts[i];
            Text(text.Item1, text.Item2);
        }
    }

}

