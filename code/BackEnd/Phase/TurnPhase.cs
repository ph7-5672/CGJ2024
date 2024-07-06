using Godot;

namespace Cgj_2024.code.BackEnd.Phase
{
    public abstract class TurnPhase
    {
        public static TurnPhase New(PhaseType turnPhase, World world, Turn turn)
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
            phase.World = world;
            phase.Turn = turn;
            return phase;
        }

        public virtual void Begin()
        {
            GD.Print($"{this} Begin");
        }
        public virtual void End()
        {
            GD.Print($"{this} End");
        }

        public World World { get; private set; }
        public Turn Turn { get; private set;}
        public bool IsPlayerContorl => Turn.IsPlayerContorl;
    }
}
