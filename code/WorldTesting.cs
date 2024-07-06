using Cgj_2024.code.BackEnd;
using Godot;
using System;

public partial class WorldTesting : Node2D
{
    public World World { get; private set; }

    [Export] PhaseType TurnPhase;
    [Export] bool IsPlayerControl;

    public override void _EnterTree()
    {
        base._EnterTree();
        World = new World();
    }

    public override void _Ready()
    {
        base._Ready();
        World.Initialzize(Parameters.Instance);
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        TurnPhase = World.CurrentTurn.CurrentRound.PhaseType;
        IsPlayerControl = World.IsPlayerControl;
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        if (@event is InputEventMouseButton mouseEvent 
            && mouseEvent.IsReleased() && mouseEvent.ButtonIndex == MouseButton.Left)
        {
            World.NextPhase();
        }
    }
}
