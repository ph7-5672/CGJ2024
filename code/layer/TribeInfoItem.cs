using Cgj_2024.code.BackEnd;
using Godot;
using System.Linq;

public partial class TribeInfoItem : Button
{
	public override void _Ready()
	{
		Pressed += () => { GD.Print(Tribe.Name); };
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

	[Export]
	Label tribeNameLabel;

	[Export]
	Label tribeDesiresLabel;
}
