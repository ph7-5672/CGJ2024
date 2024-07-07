using Cgj_2024.code.BackEnd.Factions;
using Cgj_2024.code.BackEnd.Phase;
using Godot;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static Godot.HttpRequest;

namespace Cgj_2024.code.BackEnd
{
	public class World
    {
        public World() {
            Rng = new RandomNumberGenerator();

            Territory = [];
            Goblin = new Goblin(this);
            Human = new Human(this);
        }

        public void Initialzize(Parameters parameters)
        {
            Rng.Seed = (ulong)parameters.Seed;

            Goblin.Initialze(Rng.RandiRange(1, parameters.WorldSize), Rng, parameters);
            Human.Initialze(Rng.RandiRange(10, parameters.WorldSize), Rng, parameters);

            CurrentTurn = new Turn(this);
            CurrentTurn.Begin();
        }

        public WorldState NextPhase()
        {
            WorldState result = IsWin();
            if (result == WorldState.Ongoing)
            {
                if (CurrentTurn.Next())
                {
                    CurrentTurn.End();
                    LastTurn = CurrentTurn;
                    CurrentTurn = new Turn(this);
                    CurrentTurn.Begin();
                }
            }
            
            return result;
        }

        public WorldState IsWin()
        {
            if (Goblin.Tribes.Count == 0)
            {
                CurrentTurn.CurrentRound.PhaseType = PhaseType.Lose;
                return WorldState.Lose;
            }
            else if (Human.Tribes.Count == 0)
            {
                CurrentTurn.CurrentRound.PhaseType = PhaseType.Win;
                return WorldState.Win;
            }
            return WorldState.Ongoing;
        }

        public RandomNumberGenerator Rng { get; private set; }

        public List<Territory> Territory { get; private set; }

        public Goblin Goblin { get; private set; }
        public Human Human { get; private set; }

        public RoundPhase CurrentPhase => CurrentTurn.CurrentRound.CurrentPhase;
        public Faction CurrentControl => CurrentTurn.IsPlayerContorl ? Goblin : Human;
        public bool IsPlayerControl => CurrentTurn.IsPlayerContorl;

        #region Turn
        public Turn CurrentTurn { get; private set; }
        public Turn LastTurn { get; private set; }

        #endregion Turn
    }

    public enum WorldState
    {
        Ongoing,
        Win,
        Lose,
    }
}
