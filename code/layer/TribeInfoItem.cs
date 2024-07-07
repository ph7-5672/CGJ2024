using Cgj_2024.code.BackEnd;
using Godot;
using System.Linq;

public partial class TribeInfoItem : Button
{
	public override void _Ready()
	{
		isSelected = false;
		Pressed += () =>
		{
			if (!isSelected)
			{
				if (Player_Reward_UI.rewardedTerritoryCount == 0)
				{
					isSelected = true;
					Player_Reward_UI.rewardedTerritoryCount += 1;
				}
			}
			else
			{
				isSelected = false;
				Player_Reward_UI.rewardedTerritoryCount -= 1;
			}

			GD.Print(Tribe.Name);
		};
	}

	public override void _Process(double delta)
	{
		goblinHead.Visible = isSelected;
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

	public bool isSelected { get; private set; }

	[Export]
	TextureRect goblinHead;

	[Export]
	Label tribeNameLabel;

	[Export]
	Label tribeDesiresLabel;
}
