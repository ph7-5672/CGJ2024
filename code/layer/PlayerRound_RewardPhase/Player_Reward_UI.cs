using Cgj_2024.code;
using Cgj_2024.code.BackEnd;
using Cgj_2024.code.BackEnd.Factions;
using Godot;
using System.Linq;

public partial class Player_Reward_UI : Control
{
	public override void _Ready()
	{
		rewardTerritoryConfirmButton.Pressed += () =>
		{
			rewardedTribeForTerritory = rewardTerritoryTribeInfoList.GetChildren()
			.OfType<TribeInfoItem>()
			.First(item => item.isSelected)
			.Tribe;

			var allItems = rewardTerritoryTribeInfoList.GetChildren();
			foreach (var item in allItems)
			{
				item.QueueFree();
			}

			isRewardingTerritory = false;
			rewardTerritoryContainer.Visible = false;
			rewardTreasureContainer.Visible = true;

			rewardedTerritoryCount = 0;
			totalTreasureForReward = Game.Instance.SelectedHumanTerritory.Treasure;

			GD.Print(Game.Instance.SelectedHumanTerritory.Name, " ", $"可分配{totalTreasureForReward}财宝");

			FillTribeList();
		};

		rewardTreasureConfirmButton.Pressed += () =>
		{
			Game.Instance.World.CurrentTurn.TerritoryRewaredTribeGoblin = rewardedTribeForTerritory;
			GD.Print($"领地封赏给:{Game.Instance.World.CurrentTurn.TerritoryRewaredTribeGoblin.Name}");
			var allTreasureItems = rewardTreasureTribeInfoList.GetChildren().OfType<TribeInfoItemForTreasure>();
			foreach (var item in allTreasureItems)
			{
				if (item.treasure > 0)
				{
					Game.Instance.World.CurrentTurn.TreasureRewaredTribes.Add(item.Tribe, item.treasure);
				}

				item.QueueFree();
			}

			isRewardingTerritory = true;
			rewardTerritoryContainer.Visible = true;
			rewardTreasureContainer.Visible = false;

			totalTreasureForReward = 0;

			Game.Instance.World.NextPhase();
		};

		isRewardingTerritory = true;
	}

	public override void _Process(double delta)
	{
		var currentRound = Game.Instance.World.CurrentTurn.CurrentRound;
		var phaseType = currentRound.PhaseType;

		var previousVisible = Visible;
		Visible = currentRound.CurrentContorl is Goblin && phaseType == PhaseType.Reward;

		if (!previousVisible && Visible)
		{
			FillTribeList();
		}

		rewardTerritoryConfirmButton.Disabled = rewardedTerritoryCount == 0;
		rewardTreasureConfirmButton.Disabled = totalTreasureForReward > 0;

		if (Visible)
		{
			rewardTreasureTipsLabel.Text = $"要把{totalTreasureForReward}个财宝赏赐给哪些部落？";
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
				var infoItem = tribeInfoItemForTreasure.Instantiate() as TribeInfoItemForTreasure;
				infoItem.Tribe = tribe;
				rewardTreasureTribeInfoList.AddChild(infoItem);
			}
		}
	}

	public static int rewardedTerritoryCount = 0;
	public static int totalTreasureForReward = 0;

	bool isRewardingTerritory;

	Tribe rewardedTribeForTerritory;

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

	[Export]
	Label rewardTreasureTipsLabel;
}
