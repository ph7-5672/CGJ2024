using Cgj_2024.code;
using Cgj_2024.code.BackEnd.Factions;
using Godot;

public partial class Player_Reward_UI : Control
{
	public override void _Ready()
	{
		rewardTerritoryConfirmButton.Pressed += () =>
		{
			isRewardingTerritory = false;
			rewardTerritoryContainer.Visible = false;
			rewardTreasureContainer.Visible = true;

			FillTribeList();
		};

		rewardTreasureConfirmButton.Pressed += Game.Instance.World.NextPhase;

		isRewardingTerritory = true;
	}

	public override void _Process(double delta)
	{
		var currentRound = Game.Instance.World.CurrentTurn.CurrentRound;
		var phaseType = currentRound.PhaseType;

		var previousVisible = Visible;
		Visible = currentRound.CurrentContorl is Goblin && phaseType == Cgj_2024.code.BackEnd.PhaseType.Reward;

		if (!previousVisible && Visible)
		{
			FillTribeList();
		}
	}

	void FillTribeList()
	{
		var allGoblinTribes = Game.Instance.World.Goblin.Tribes;
		foreach (var tribe in allGoblinTribes)
		{
			if (isRewardingTerritory)
			{
				var infoItem = tribeInfoItemForTerritory.Instantiate() as TribeInfoItem;
				infoItem.Tribe = tribe;
				rewardTerritoryTribeInfoList.AddChild(infoItem);
			}
			else
			{
				var infoItem = tribeInfoItemForTreasure.Instantiate() as TribeInfoItem;
				infoItem.Tribe = tribe;
				rewardTreasureTribeInfoList.AddChild(infoItem);
			}
		}
	}

	bool isRewardingTerritory;

	[Export]
	PackedScene tribeInfoItemForTerritory;

	[Export]
	PackedScene tribeInfoItemForTreasure;

	[Export]
	VBoxContainer rewardTerritoryTribeInfoList;

	[Export]
	VBoxContainer rewardTreasureTribeInfoList;

	[Export]
	CenterContainer rewardTerritoryContainer;

	[Export]
	CenterContainer rewardTreasureContainer;

	[Export]
	Button rewardTerritoryConfirmButton;

	[Export]
	Button rewardTreasureConfirmButton;
}
