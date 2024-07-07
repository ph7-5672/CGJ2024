using Cgj_2024.code;
using Cgj_2024.code.BackEnd.Factions;
using Cgj_2024.code.BackEnd.Phase;
using Godot;

public partial class TipsLabel : Label
{

    public override void _Process(double delta)
    {
        var phase = Game.Instance.World.CurrentPhase;
        if (Game.Instance.World.CurrentTurn.CurrentRound.CurrentContorl is Goblin) // Player Round
        {
            Visible = true;
            if (phase is BeginPhase)
            {
                Text = "你的回合";
            }
            if (phase is SelectTerritoryPhase)
            {
                Text = "请选择要进攻的人类领地";
            }
            if (phase is MobilisePhase)
            {
                Text = "请选择要动员的部落";
            }
            if (phase is SettlePhase)
            {
                Text = "要把领地赏赐给哪个部落？";
            }
            if (phase is RewardPhase)
            {
                Text = "请选择要进攻的人类领地";
            }
            else
            {
                Visible = false;
            }
        }
        else // AI Round
        {
            Visible = false;
        }
    }

}