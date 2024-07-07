
using Cgj_2024.code;
using Cgj_2024.code.BackEnd.Factions;
using Cgj_2024.code.BackEnd.Phase;
using Godot;

public partial class Player_SelectEnemy_UI : Control
{
    [Export]
    Button confirmButton;

    [Export]
    Button cancelButton;

    public override void _Ready()
    {
        confirmButton.Pressed += Game.Instance.World.NextPhase;
    }

    public override void _Process(double delta)
    {
        confirmButton.Disabled = Game.Instance.SelectedHumanTerritory == null;
        Visible = Game.Instance.World.CurrentPhase is SelectTerritoryPhase && Game.Instance.World.CurrentControl is Goblin;
    }

}
