using Cgj_2024.code;
using Cgj_2024.code.BackEnd.Phase;
using Godot;

public partial class BattleButton : Button
{
    public override void _Ready()
    {
        Pressed += () =>
        {
            Game.Instance.World.NextPhase();
        };  
    }

    public override void _Process(double delta)
    {
        Visible = Game.Instance.World.CurrentPhase is BeginPhase;
    }
}
