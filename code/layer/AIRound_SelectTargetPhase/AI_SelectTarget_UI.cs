using Cgj_2024.code;
using Cgj_2024.code.BackEnd;
using Cgj_2024.code.BackEnd.Factions;
using Godot;

public partial class AI_SelectTarget_UI : Control
{
	public override void _Ready()
	{
		confirmButton.Pressed += () => { Game.Instance.World.NextPhase(); };
    }

	public override void _Process(double delta)
	{
		var currentRound = Game.Instance.World.CurrentTurn.CurrentRound;
		var phaseType = currentRound.PhaseType;
		Visible = currentRound.CurrentContorl is Human && phaseType == Cgj_2024.code.BackEnd.PhaseType.SelectEnemyTerritory
            && Game.Instance.World.CurrentTurn.CurrentRound.PhaseType != PhaseType.Lose
            && Game.Instance.World.CurrentTurn.CurrentRound.PhaseType != PhaseType.Win;
	}

	[Export]
	Button confirmButton;
}
