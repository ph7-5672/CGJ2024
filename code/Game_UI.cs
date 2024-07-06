/*
 * ImGui，负责UI显示。
 */
using Godot;
using Godot.Collections;
using ImGuiGodot;
using ImGuiNET;

namespace Cgj_2024.code;

public partial class Game
{
    /// <summary>
    /// 满足和不满足的图标。
    /// </summary>
    [Export]
    Array<Texture2D> satisfiedIcons;


    // TODO 领地分配 和 金币分配
    void EnterTree_UI()
    {
        ImGui.StyleColorsLight();
    }

    /// <summary>
    /// 哥布林领地列表UI。
    /// </summary>
    void GoblinTerritories_UI()
    {
        ImGui.PushStyleColor(ImGuiCol.WindowBg, Colors.LightYellow.ToVector4());
        ImGui.Begin("##goblin_territories", ImGuiWindowFlags.NoTitleBar);
        // 部落层。
        if (ImGui.BeginTable("tribes", 1))
        {
            ImGui.TableNextColumn();

            ImGui.Text("部落A");
            ImGui.SameLine(0f, 0f);

            var mobilized = true;
            var index = mobilized ? 0 : 1;
            var texture = satisfiedIcons[index];
            var size = new Vector2(32f, 32f);
            var rect = Image(texture, size);
            
            if (ImGui.IsMouseHoveringRect(rect.Position.ToSystemNumerics(), rect.Position.ToSystemNumerics() + rect.Size.ToSystemNumerics()))
            {
                ImGui.BeginTooltip();
                var tooltip = mobilized ? "满足" : "不满足";
                ImGui.Text(tooltip);
                ImGui.EndTooltip();
            }
            
            // 领地层。
            ImGui.PushStyleColor(ImGuiCol.TableRowBg, Colors.Burlywood.ToVector4());
            ImGui.PushStyleColor(ImGuiCol.TableRowBgAlt, Colors.Transparent.ToVector4());
            if (ImGui.BeginTable("territories", 1, ImGuiTableFlags.RowBg))
            {
                ImGui.TableNextColumn();
                ImGui.Text("领地A");
                ImGui.Text("兵力：5");
                ImGui.Text("财力：5");

                // 空白行。
                ImGui.TableNextColumn();

                ImGui.TableNextColumn();
                ImGui.Text("领地B");
                ImGui.Text("兵力：1");
                ImGui.Text("财力：2");
                ImGui.EndTable();
            }

            ImGui.TableNextColumn();
            ImGui.Text("部落B");
            ImGui.SameLine(0f, 0f);

            mobilized = false;
            index = mobilized ? 0 : 1;
            texture = satisfiedIcons[index];
            size = new Vector2(32f, 32f);
            rect = Image(texture, size);

            if (ImGui.IsMouseHoveringRect(rect.Position.ToSystemNumerics(), rect.Position.ToSystemNumerics() + rect.Size.ToSystemNumerics()))
            {
                ImGui.BeginTooltip();
                var tooltip = mobilized ? "满足" : "不满足";
                ImGui.Text(tooltip);
                ImGui.EndTooltip();
            }

            // 领地层。
            if (ImGui.BeginTable("territories", 1, ImGuiTableFlags.RowBg))
            {
                ImGui.TableNextColumn();
                ImGui.Text("领地C");
                ImGui.Text("兵力：5");
                ImGui.Text("财力：5");

                // 空白行。
                ImGui.TableNextColumn();

                ImGui.TableNextColumn();
                ImGui.Text("领地D");
                ImGui.Text("兵力：1");
                ImGui.Text("财力：2");
                ImGui.EndTable();
            }

            ImGui.PopStyleColor();
            ImGui.PopStyleColor();

            ImGui.EndTable();
        }
        
        ImGui.End();
        ImGui.PopStyleColor();
    }

    /// <summary>
    /// 人类领地列表UI。
    /// </summary>
    void HumanTerritories_UI()
    {
        ImGui.Begin("##human_territories", ImGuiWindowFlags.NoTitleBar);
        TribesTable();
        ImGui.End();
    }

    /// <summary>
    /// 游戏状态信息。
    /// </summary>
    void GameState_UI()
    {
        ImGui.Begin("##游戏状态");



        ImGui.End();

        /*ImGui.OpenPopup("Dialog");
        if (ImGui.BeginPopupModal("Dialog"))
        {
            ImGui.Text("测试");
            ImGui.Separator();
            ImGui.EndPopup();
        }*/

        /*ImGui.BeginTooltip();
        ImGui.Text("测试提示信息");
        ImGui.EndTooltip();*/
        
    }


    void TribesTable()
    {
        ImGui.BeginTable("tribes", 1);

        ImGui.TableNextColumn();
        ImGui.Text("部落A");

        var mobilized = true;
        if (mobilized)
        {
            // 笑脸图标。
            ImGui.SameLine();
            ImGui.Text("😀");
        }
        TerritoriesTable();


        ImGui.TableNextColumn();
        ImGui.Text("部落B");

        TerritoriesTable();

        ImGui.EndTable();
    }


    void TerritoriesTable()
    {
        ImGui.BeginTable("territories", 1, ImGuiTableFlags.BordersOuter | ImGuiTableFlags.BordersInnerH);

        ImGui.TableNextColumn();
        ImGui.Text("领地A");
        ImGui.Text("兵力：5");
        ImGui.Text("财力：5");

        ImGui.TableNextColumn();
        ImGui.Text("领地B");
        ImGui.Text("兵力：1");
        ImGui.Text("财力：2");

        ImGui.EndTable();
    }

    /// <summary>
    /// 领地分配
    /// </summary>    
    void DispenseTerritory_UI()
    { 

    }


    public override void _Process(double delta)
    {
        GoblinTerritories_UI();
        HumanTerritories_UI();
        GameState_UI();
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

    public static void Image(Texture2D texture)
    {
        Image(texture, Vector2.Zero);
    }


    public static Rect2 Image(Texture2D texture, Vector2 size)
    {
        var pos = ImGui.GetCursorPos() + ImGui.GetWindowPos();
        if (size == Vector2.Zero)
        { 
            size = texture.GetSize();
        }
        var id = ImGuiGD.BindTexture(texture);
        ImGui.Image(id, size.ToSystemNumerics());
        return new Rect2(pos.ToGodotNumerics(), size);
    }

}

