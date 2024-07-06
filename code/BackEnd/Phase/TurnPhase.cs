using Godot;

namespace Cgj_2024.code.BackEnd.Phase
{
    public abstract class TurnPhase
    {
        public static TurnPhase New(PhaseType turnPhase)
        {
            TurnPhase phase = null;
            switch (turnPhase)
            {
                case PhaseType.Begin:
                    phase = new BeginPhase();
                    break;
                case PhaseType.SelectEnemyTerritory:
                    phase = new SelectTerritoryPhase();
                    break;
                case PhaseType.Mobilise:
                    phase = new MobilisePhase();
                    break;
                case PhaseType.Settle:
                    phase = new SettlePhase();
                    break;
                case PhaseType.Reward:
                    phase = new RewardPhase();
                    break;
                case PhaseType.End:
                    phase = new EndPhase();
                    break;
                default:
                    GD.PrintErr($"Unknow TurnPhase: {turnPhase}");
                    break;
            }

            return phase;
        }

        public virtual void Begin(bool isPlayerContorl)
        {
            GD.Print($"{this} Begin");
        }
        public virtual void End(bool isPlayerContorl)
        {
            GD.Print($"{this} End");
        }
    }
}
