using Cgj_2024.code;
using Cgj_2024.code.BackEnd.Factions;
using Godot;

public partial class AI_Settle_UI : Control
{
	public override void _Ready()
	{
		confirmButton.Pressed += Game.Instance.World.NextPhase;
	}

	public override void _Process(double delta)
	{
		var currentRound = Game.Instance.World.CurrentTurn.CurrentRound;
		var phaseType = currentRound.PhaseType;
		Visible = currentRound.CurrentContorl is Human && phaseType == Cgj_2024.code.BackEnd.PhaseType.Settle;

		if (Visible)
		{
			if (currentRound.BattleResult)
			{
				battleWin.Visible = true;
				battleLose.Visible = false;
				detailsLabel.Text = "防守成功！";
			}
			else
			{
				battleWin.Visible = false;
				battleLose.Visible = true;
				detailsLabel.Text = $"{currentRound.TargetedTerritory.Tribe.Name}部落 失去了 领地{currentRound.TargetedTerritory.Name}！";
			}
		}
	}

	[Export]
	TextureRect battleWin;

	[Export]
	TextureRect battleLose;

	[Export]
	Label detailsLabel;

	[Export]
	Button confirmButton;
}
