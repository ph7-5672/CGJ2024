using Cgj_2024.code;
using Godot;


public partial class CancelButton : Button
{
    public override void _Ready()
    {
        Pressed += () =>
        {
            //Game.Instance.World.();
        };
    }

    public override void _Process(double delta)
    {
        var phaseType = Game.Instance.World.CurrentTurn.CurrentRound.PhaseType;
        Visible = phaseType == Cgj_2024.code.BackEnd.PhaseType.SelectEnemyTerritory || phaseType == Cgj_2024.code.BackEnd.PhaseType.Mobilise;
    }
}
