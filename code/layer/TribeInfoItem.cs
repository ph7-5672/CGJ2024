using Cgj_2024.code.BackEnd;
using Godot;
using System.Linq;

public partial class TribeInfoItem : Control
{
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
