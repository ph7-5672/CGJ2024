using Cgj_2024.code.BackEnd;
using Godot;
using System.Linq;

public partial class TribeInfoItemForTreasure : Control
{
	public override void _Ready()
	{
		addTreasure.Pressed += () =>
		{
			treasure += 1;
		};

		removeTreasure.Pressed += () =>
		{
			treasure -= 1;
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

	int treasure;

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
