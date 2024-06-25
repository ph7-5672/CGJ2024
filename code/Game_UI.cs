
using ImGuiNET;

namespace Cgj_2024.code;

public partial class Game
{
    public override void _Process(double delta)
    {
        ImGui.Begin("test");

        ImGui.Text("你好世界！");
        ImGui.Text("Hello world!");
        ImGui.Text("1234567890");

        ImGui.End();
    }
}

