using Cgj_2024.code;
using Cgj_2024.code.BackEnd.Factions;
using Godot;
using System.Linq;

public partial class AI_Mobilise_UI : Control
{
	public override void _Ready()
	{
		confirmButton.Pressed += Game.Instance.World.NextPhase;
	}

	public override void _Process(double delta)
	{
		var currentRound = Game.Instance.World.CurrentTurn.CurrentRound;
		var phaseType = currentRound.PhaseType;
		Visible = currentRound.CurrentContorl is Human && phaseType == Cgj_2024.code.BackEnd.PhaseType.Mobilise;

		if (Visible)
		{
			var defenderTroops = Game.Instance.SelectedGoblinTribes.Select(t => t.Troops).Sum();
			attackerDetailsLabel.Text = $"兵力：{currentRound.AIMobilizedTribes.Sum(tribe => tribe.Troops)}";
			defenderDetailsLabel.Text = $"兵力：{defenderTroops}";
		}
	}

	[Export]
	Label attackerDetailsLabel;

	[Export]
	Label defenderDetailsLabel;

	[Export]
	Button confirmButton;
}
