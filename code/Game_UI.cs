﻿/*
 * ImGui，负责UI显示。
 */
using Godot;
using Godot.Collections;
using ImGuiGodot;
using ImGuiNET;

namespace Cgj_2024.code;

public partial class Game
{

    ImGuiStylePtr style;

    Vector2 uiScale;

    [ExportGroup("UI素材导入")]

    [Export]
    Texture2D goblinBg;
  
    [Export]
    Array<Texture2D> goblinTibreRowsBg;

    [Export]
    Array<Texture2D> goblinEmotionsIcon;

    [Export]
    Texture2D goblinTipsBg;

    [Export]
    Texture2D humanBg;

    [Export]
    Array<Texture2D> humanTibreRowsBg;

    


    // TODO 领地分配 和 金币分配
    void EnterTree_UI()
    {
        uiScale = DisplayServer.WindowGetSize() / new Vector2(640, 480);
        ImGui.StyleColorsLight();
        style = ImGui.GetStyle();
    }

    /// <summary>
    /// 哥布林领地列表UI。
    /// </summary>
    void GoblinTerritories_UI()
    {
        var pos = new System.Numerics.Vector2(10f, 10f);
        var size = goblinBg.GetSize() * uiScale;
        ImGui.SetNextWindowBgAlpha(0);
        ImGui.SetNextWindowSize(size.ToSystemNumerics());
        ImGui.SetNextWindowPos(pos);

        ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, System.Numerics.Vector2.Zero);
        ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0);

        ImGui.Begin("##哥布林领地背景", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoInputs);
        {
            Image(goblinBg, size);

        }
        ImGui.End();

        var padding = new System.Numerics.Vector2(30f, 37f);
        ImGui.SetNextWindowBgAlpha(0);
        ImGui.SetNextWindowSize(size.ToSystemNumerics() - padding * 2);
        ImGui.SetNextWindowPos(pos + padding);

        ImGui.Begin("##哥布林领地列表", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove);
        for (int i = 0; i < World.Goblin.Tribes.Count; i++)
        {
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, System.Numerics.Vector2.Zero);
            var tribe = World.Goblin.Tribes[i];
            var title = goblinTibreRowsBg[0];
            Image(title, title.GetSize() * uiScale);
            ImGui.SameLine(20f, 0f);
            ImGui.BeginGroup();
            ImGui.Dummy(new System.Numerics.Vector2(0f, 23f));
            Text(tribe.Name ?? "部落", Colors.AliceBlue);
            ImGui.EndGroup();
            ImGui.SameLine(180f);
            ImGui.BeginGroup();
            ImGui.Dummy(new System.Numerics.Vector2(0f, 18f));
            var icon = tribe.IsMobilized ? goblinEmotionsIcon[0] : goblinEmotionsIcon[1];
            var rect = Image(icon, icon.GetSize() * uiScale);

            if (ImGui.IsMouseHoveringRect(rect.Position.ToSystemNumerics(), rect.Position.ToSystemNumerics() + rect.Size.ToSystemNumerics()))
            {
                ImGui.SetNextWindowBgAlpha(0);
                ImGui.GetWindowDrawList().AddCallback(0, 0);
                ImGui.PushStyleVar(ImGuiStyleVar.PopupBorderSize, 0);
                
                ImGui.BeginTooltip();
                Image(goblinTipsBg, goblinTipsBg.GetSize() * uiScale);
                ImGui.EndTooltip();
                ImGui.PopStyleVar();
            }
            ImGui.EndGroup();

            for (int j = 0; j < tribe.Territory.Count; ++j)
            {
                var territory = tribe.Territory[j];
                if (j == 0)
                {
                    Image(goblinTibreRowsBg[1], title.GetSize() * uiScale);
                }
                else if (j == tribe.Territory.Count - 1)
                {
                    Image(goblinTibreRowsBg[3], title.GetSize() * uiScale);
                }
                else
                {
                    Image(goblinTibreRowsBg[2], title.GetSize() * uiScale);
                }
                ImGui.SameLine(20f, 0f);
                ImGui.BeginGroup();
                ImGui.Dummy(new System.Numerics.Vector2(0f, 10f));
                ImGui.Text(territory.Name ?? "领地");
                ImGui.Text($"兵力：{territory.Troops}");
                ImGui.SameLine(0f, 20f);
                ImGui.Text($"财力：{territory.Treasure}");
                ImGui.EndGroup();
            }
            ImGui.PopStyleVar();
            ImGui.Dummy(new System.Numerics.Vector2(0, 10f));
        }

        ImGui.End();
        ImGui.PopStyleVar(2);
    }

    /// <summary>
    /// 人类领地列表UI。
    /// </summary>
    void HumanTerritories_UI()
    {
        var displaySize = DisplayServer.WindowGetSize();
        var offset = new System.Numerics.Vector2(10f, 10f);
        var size = goblinBg.GetSize() * uiScale;
        var pos = new System.Numerics.Vector2(displaySize.X - size.X - offset.X, offset.Y);
        ImGui.SetNextWindowBgAlpha(0);
        ImGui.SetNextWindowSize(size.ToSystemNumerics());
        ImGui.SetNextWindowPos(pos);

        ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, System.Numerics.Vector2.Zero);
        ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0);

        ImGui.Begin("##人类领地背景", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoInputs);
        {
            Image(goblinBg, size);

        }
        ImGui.End();

        var padding = new System.Numerics.Vector2(30f, 37f);
        ImGui.SetNextWindowBgAlpha(0);
        ImGui.SetNextWindowSize(size.ToSystemNumerics() - padding * 2);
        ImGui.SetNextWindowPos(pos + padding);

        ImGui.Begin("##人类领地列表", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove);
        for (int i = 0; i < World.Goblin.Tribes.Count; i++)
        {
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, System.Numerics.Vector2.Zero);
            var tribe = World.Human.Tribes[i];
            var title = goblinTibreRowsBg[0];
            Image(title, title.GetSize() * uiScale);
            ImGui.SameLine(20f, 0f);
            ImGui.BeginGroup();
            ImGui.Dummy(new System.Numerics.Vector2(0f, 23f));
            Text(tribe.Name ?? "领主", Colors.AliceBlue);
            ImGui.EndGroup();
            for (int j = 0; j < tribe.Territory.Count; ++j)
            {
                var territory = tribe.Territory[j];
                if (j == 0)
                {
                    Image(goblinTibreRowsBg[1], title.GetSize() * uiScale);
                }
                else if (j == tribe.Territory.Count - 1)
                {
                    Image(goblinTibreRowsBg[3], title.GetSize() * uiScale);
                }
                else
                {
                    Image(goblinTibreRowsBg[2], title.GetSize() * uiScale);
                }
                ImGui.SameLine(20f, 0f);
                ImGui.BeginGroup();
                ImGui.Dummy(new System.Numerics.Vector2(0f, 10f));
                ImGui.Text(territory.Name ?? "领地");
                ImGui.Text($"兵力：{territory.Troops}");
                ImGui.SameLine(0f, 20f);
                ImGui.Text($"财力：{territory.Treasure}");
                ImGui.EndGroup();
            }
            ImGui.PopStyleVar();
            ImGui.Dummy(new System.Numerics.Vector2(0, 10f));
        }

        ImGui.End();
        ImGui.PopStyleVar(2);
    }



    /// <summary>
    /// 游戏交互区域。
    /// </summary>
    void Interact_UI()
    {
        /*var windowSize = new Vector2(100f, );
        ImGui.SetNextWindowPos();
        ImGui.Begin("##游戏交互", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoBackground | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoResize);
        ImGui.Button("准备进攻！");
        ImGui.End();*/

       
        
    }



    /// <summary>
    /// 领地分配
    /// </summary>    
    void DispenseTerritory_UI()
    { 

    }


    public void Process_UI(double delta)
    {
        GoblinTerritories_UI();
        HumanTerritories_UI();
        Interact_UI();
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

