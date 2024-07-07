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
			isSelected = !isSelected;
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

	bool isSelected;

	[Export]
	TextureRect goblinHead;

	[Export]
	Label tribeNameLabel;

	[Export]
	Label tribeDesiresLabel;
}
