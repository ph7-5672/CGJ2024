using Cgj_2024.code.BackEnd;
using Godot;
using System.Linq;

public partial class TribeInfoItemForTreasure : Control
{
	public override void _Ready()
	{
		addTreasure.Pressed += () =>
		{
			if (Player_Reward_UI.totalTreasureForReward > 0)
			{
				Player_Reward_UI.totalTreasureForReward -= 1;
				treasure += 1;
			}
		};

		removeTreasure.Pressed += () =>
		{
			if (treasure > 0)
			{
				treasure -= 1;
				Player_Reward_UI.totalTreasureForReward += 1;
			}
		};
	}

	public override void _Process(double delta)
	{
		treasureLabel.Text = $"{treasure}金币";
	}

	public Tribe Tribe
	{
		get => tribe;
		set
		{
			tribe = value;
			tribeNameLabel.Text = tribe.Name;
			tribeDesiresLabel.Text = string.Join("\n", tribe.Desires.Select(desire => $"- {desire.Description}"));
		}
	}

	Tribe tribe;

	public int treasure;

	[Export]
	Label treasureLabel;

	[Export]
	Button addTreasure;

	[Export]
	Button removeTreasure;

	[Export]
	Label tribeNameLabel;

	[Export]
	Label tribeDesiresLabel;
}
