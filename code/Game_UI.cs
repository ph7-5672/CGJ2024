/*
 * ImGui，负责UI显示。
 */
using Cgj_2024.code.BackEnd.Phase;
using Godot;
using Godot.Collections;
using ImGuiGodot;
using ImGuiNET;
using System.Collections.Generic;

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

    [Export]
    Texture2D attackButtonTexture;

    public System.Collections.Generic.Dictionary<int, bool> SelectedGoblinMap { get; private set; } = new();

    public int SelectedHumanIndex { get; private set; } = -1;

    bool mousePressedLastFrame;

    // TODO 领地分配 和 金币分配
    void EnterTree_UI()
    {
        uiScale = DisplayServer.WindowGetSize() / new Vector2(640, 480);
        style = ImGui.GetStyle();
    }

    /// <summary>
    /// 哥布林领地列表UI。
    /// </summary>
    void GoblinTerritories_UI()
    {
        var phaseType = World.CurrentTurn.PlayerRound.PhaseType;
        var visible = phaseType == BackEnd.PhaseType.Begin
                   || phaseType == BackEnd.PhaseType.Mobilise;


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
            var tribeRect = Image(title, title.GetSize() * uiScale);
            tribeRect.Position = new Vector2(tribeRect.Position.X, tribeRect.Position.Y - ImGui.GetScrollY());
            ImGui.SameLine(20f, 0f);
            ImGui.BeginGroup();
            ImGui.Dummy(new System.Numerics.Vector2(0f, 28f));
            Text($"{tribe.Name}部落", Colors.AliceBlue);
            ImGui.EndGroup();
            ImGui.SameLine(180f);
            ImGui.BeginGroup();
            ImGui.Dummy(new System.Numerics.Vector2(0f, 18f));
            var icon = tribe.CanBeMobilized ? goblinEmotionsIcon[0] : goblinEmotionsIcon[1];
            var inconRect = Image(icon, icon.GetSize() * uiScale);
            inconRect.Position = new Vector2(inconRect.Position.X, inconRect.Position.Y - ImGui.GetScrollY());
            var isHovered = ImGui.IsMouseHoveringRect(inconRect.Position.ToSystemNumerics(), inconRect.Position.ToSystemNumerics() + inconRect.Size.ToSystemNumerics());
            if (visible && isHovered)
            {
                ImGui.SetNextWindowBgAlpha(0);
                ImGui.PushStyleVar(ImGuiStyleVar.PopupBorderSize, 0);
                // 每行最多显示11个等距像素字符
                ImGui.BeginTooltip();
                Image(goblinTipsBg, goblinTipsBg.GetSize() * uiScale);
                ImGui.SameLine(35f);
                ImGui.BeginGroup();
                ImGui.Dummy(new System.Numerics.Vector2(0f, 20f));
				Text($"欲望{(tribe.CanBeMobilized ? "已" : "未")}被满足", Colors.Black);
                foreach (var desire in tribe.Desires)
                {
                    Text("欲望", Colors.Black);
                }
				ImGui.EndGroup();
                ImGui.EndTooltip();
                ImGui.PopStyleVar();
            }
            ImGui.EndGroup();

            for (int j = 0; j < tribe.Territory.Count; ++j)
            {
                var territory = tribe.Territory[j];
                float height;
                if (j == 0)
                {
                    height = Image(goblinTibreRowsBg[1], title.GetSize() * uiScale).Size.Y;
                }
                else if (j == tribe.Territory.Count - 1)
                {
                    height = Image(goblinTibreRowsBg[3], title.GetSize() * uiScale).Size.Y;
                }
                else
                {
                    height = Image(goblinTibreRowsBg[2], title.GetSize() * uiScale).Size.Y;
                }
                ImGui.SameLine(20f, 0f);
                ImGui.BeginGroup();
                ImGui.Dummy(new System.Numerics.Vector2(0f, 5f));
                ImGui.Text(territory.Name ?? "领地");
                ImGui.Text($"兵力：{territory.Troops}");
                ImGui.Text($"财力：{territory.Treasure}");
                ImGui.EndGroup();

                tribeRect.Size = new Vector2(tribeRect.Size.X, tribeRect.Size.Y + height);
            }
            ImGui.PopStyleVar();
            ImGui.Dummy(new System.Numerics.Vector2(0, 10f));

            if (phaseType == BackEnd.PhaseType.Mobilise)
            {
                if (tribe.CanBeMobilized 
                    && !Input.IsMouseButtonPressed(MouseButton.Left) && mousePressedLastFrame
                    && ImGui.IsMouseHoveringRect(tribeRect.Position.ToSystemNumerics(), tribeRect.Size.ToSystemNumerics() + tribeRect.Position.ToSystemNumerics()))
                {
                    if (SelectedGoblinMap.TryGetValue(i, out var selected))
                    {
                        selected = !selected;
                        SelectedGoblinMap[i] = selected;
                    }
                    else
                    {
                        SelectedGoblinMap.Add(i, true);
                    }
                }

                if (!SelectedGoblinMap.TryGetValue(i, out var s) || !s)
                {
                    var drawList = ImGui.GetWindowDrawList();
                    drawList.AddRectFilled(tribeRect.Position.ToSystemNumerics(), tribeRect.Position.ToSystemNumerics() + tribeRect.Size.ToSystemNumerics(), new Color(0, 0, 0, 0.5f).ToArgb32());
                }

                
            }

        }

        ImGui.End();
        ImGui.PopStyleVar(2);

        // 遮罩
        if (visible)
        {
            return;
        }
        ImGui.SetNextWindowBgAlpha(0.7f);
        ImGui.SetNextWindowSize(size.ToSystemNumerics());
        ImGui.SetNextWindowPos(pos);
        ImGui.Begin("##哥布林列表遮罩", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove);
        ImGui.End();

    }

    /// <summary>
    /// 人类领地列表UI。
    /// </summary>
    void HumanTerritories_UI()
    {
        var phaseType = World.CurrentTurn.PlayerRound.PhaseType;
        var visible = phaseType == BackEnd.PhaseType.Begin
                   || phaseType == BackEnd.PhaseType.SelectEnemyTerritory
                   || phaseType == BackEnd.PhaseType.Mobilise;

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
            Image(humanBg, size);

        }
        ImGui.End();

        var padding = new System.Numerics.Vector2(30f, 37f);
        ImGui.SetNextWindowBgAlpha(0);
        ImGui.SetNextWindowSize(size.ToSystemNumerics() - padding * 2);
        ImGui.SetNextWindowPos(pos + padding);

        ImGui.Begin("##人类领地列表", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove);
        
        for (int i = 0; i < World.Human.Tribes.Count; i++)
        {
            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, System.Numerics.Vector2.Zero);
            var tribe = World.Human.Tribes[i];
            var title = humanTibreRowsBg[0];
            var rect = Image(title, title.GetSize() * uiScale);
            rect.Position = new Vector2(rect.Position.X, rect.Position.Y - ImGui.GetScrollY());
            ImGui.SameLine(20f, 0f);
            ImGui.BeginGroup();
            ImGui.Dummy(new System.Numerics.Vector2(0f, 23f));
            Text($"{tribe.Name}大人", Colors.AliceBlue);
            ImGui.EndGroup();
            for (int j = 0; j < tribe.Territory.Count; ++j)
            {
                var territory = tribe.Territory[j];
                float height;
                if (j == tribe.Territory.Count - 1)
                {
                    height = Image(humanTibreRowsBg[3], title.GetSize() * uiScale).Size.Y;
                }
                else if (j == 0)
                {
                    height = Image(humanTibreRowsBg[1], title.GetSize() * uiScale).Size.Y;
                }
                else
                {
                    height = Image(humanTibreRowsBg[2], title.GetSize() * uiScale).Size.Y;
                }
                ImGui.SameLine(20f, 0f);
                ImGui.BeginGroup();
                ImGui.Dummy(new System.Numerics.Vector2(0f, 5f));
                Text(territory.Name ?? "领地", Colors.White);
                Text($"兵力：{territory.Troops}", Colors.White);
                Text($"财力：{territory.Treasure}", Colors.White);
                ImGui.EndGroup();

                rect.Size = new Vector2(rect.Size.X, rect.Size.Y + height);
            }
            ImGui.PopStyleVar();
            ImGui.Dummy(new System.Numerics.Vector2(0, 10f));

            if (phaseType == BackEnd.PhaseType.SelectEnemyTerritory
                    && Input.IsMouseButtonPressed(MouseButton.Left)
                    && ImGui.IsMouseHoveringRect(rect.Position.ToSystemNumerics(), rect.Position.ToSystemNumerics() + rect.Size.ToSystemNumerics()))
            {
                SelectedHumanIndex = i;
                World.NextPhase();
            }

            if (visible && SelectedHumanIndex != i)
            {
                var drawList = ImGui.GetWindowDrawList();
                drawList.AddRectFilled(rect.Position.ToSystemNumerics(), rect.Position.ToSystemNumerics() + rect.Size.ToSystemNumerics(), new Color(0, 0, 0, 0.5f).ToArgb32());
            }
        }

        ImGui.End();
        ImGui.PopStyleVar(2);

        // 遮罩
        if (visible)
        {
            return;
        }
        ImGui.SetNextWindowBgAlpha(0.7f);
        ImGui.SetNextWindowSize(size.ToSystemNumerics());
        ImGui.SetNextWindowPos(pos);
        ImGui.Begin("##人类列表遮罩", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove);
        ImGui.End();
    }


    public void Process_UI(double delta)
    {
        GoblinTerritories_UI();
        HumanTerritories_UI();
        mousePressedLastFrame = Input.IsMouseButtonPressed(MouseButton.Left);
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
        var resizedTexture = ResizeTextureNearest(texture, (int)size.X, (int)size.Y);
        Widgets.Image(resizedTexture, size.ToSystemNumerics());
        return new Rect2(pos.ToGodotNumerics(), size);
    }

    static System.Collections.Generic.Dictionary<Rid, Texture2D> resizeMap = new();

    public static Texture2D ResizeTextureNearest(Texture2D source, int width, int height)
    {
        var rid = source.GetRid();
        if (resizeMap.TryGetValue(rid, out var resizedTexture))
        {
            return resizedTexture;
        }

        // 创建一个新的Image对象，用于存储放大后的图像数据  
        var image = source.GetImage();
        image.Resize(width, height, Godot.Image.Interpolation.Nearest);
        resizedTexture = ImageTexture.CreateFromImage(image);
        resizeMap.Add(rid, resizedTexture);
        return resizedTexture;
    }


    public static Vector2 ScreenCenterPos(Vector2 size)
    {
        return (DisplayServer.WindowGetSize() - size) / 2;
    }

    public static Vector2 WindowCenterPos(Vector2 size)
    {
        return (ImGui.GetWindowSize().ToGodotNumerics() - size) / 2;
    }


}

