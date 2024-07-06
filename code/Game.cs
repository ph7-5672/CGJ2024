/*
 * 在这里控制游戏流程。
 */

using Cgj_2024.code.BackEnd;
using Godot;

namespace Cgj_2024.code;

public partial class Game : Node2D
{ 
    public static Game Instance { get; private set; }

    public override void _EnterTree()
    {
        base._EnterTree();
        World = new World();

        Instance = this;
        // 各个模块的初始化。
        EnterTree_UI();
    }

    public World World { get; private set; }

    [ExportGroup("逻辑配置")]
    [Export] PhaseType TurnPhase;
    [Export] bool IsPlayerControl;

    public override void _Ready()
    {
        base._Ready();
        World.Initialzize(Parameters.Instance);
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        Process_UI(delta);

        TurnPhase = World.CurrentTurn.CurrentRound.PhaseType;
        IsPlayerControl = World.IsPlayerControl;
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        /*if (@event is InputEventMouseButton mouseEvent
            && mouseEvent.IsReleased() && mouseEvent.ButtonIndex == MouseButton.Left)
        {
            World.NextPhase();
        }*/
    }


}
