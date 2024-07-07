
using Cgj_2024.code;
using Cgj_2024.code.BackEnd.Factions;
using Cgj_2024.code.BackEnd.Phase;
using Godot;

public partial class Player_Begin_UI : Control
{
    [Export]
    Button battleButton;

    public override void _Ready()
    {
        battleButton.Pressed += Game.Instance.World.NextPhase;
    }

    public override void _Process(double delta)
    {
        Visible = Game.Instance.World.CurrentPhase is BeginPhase && Game.Instance.World.CurrentControl is Goblin;
    }

}
