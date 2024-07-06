using Cgj_2024.code.BackEnd.Factions;
using System.Collections.Generic;
using Godot;
using Cgj_2024.code.BackEnd.Phase;

namespace Cgj_2024.code.BackEnd
{
    public class World
    {
        public World() {
            Rng = new RandomNumberGenerator();

            Territory = [];
            Goblin = new Goblin();
            Human = new Human();
        }

        public void Initialzize(Parameters parameters)
        {
            Rng.Seed = (ulong)parameters.Seed;

            for (int i = 0; i < parameters.WorldSize; i++)
            {
                var territory = new Territory
                {
                    Troops = Rng.RandiRange(parameters.TroopMin, parameters.TroopMax),
                    Treasure = Rng.RandiRange(parameters.TreasureMin, parameters.TreasureMax)
                };
                Territory.Add(territory);
            }

            int size = Territory.Count >> 1;
            Goblin.Initialze(Territory[..size]);
            Human.Initialze(Territory[size..]);

            CurrentTurn = new Turn(this);

            PhaseType = PhaseType.Begin;
            CurrentPhase = TurnPhase.New(PhaseType, this, CurrentTurn);
            IsPlayerControl = true;
            CurrentControl = Goblin;
            Goblin.BeginTurn(true);
            CurrentPhase.Begin();
        }

        public void NextPhase()
        {
            bool takeControl = false;
            if (PhaseType != PhaseType.End)
            {
                PhaseType++;
            }
            else
            {
                PhaseType = PhaseType.Begin;
                takeControl = true;
                IsPlayerControl = !IsPlayerControl;
            }

            CurrentPhase.End();
            if (takeControl)
            {
                CurrentControl.EndTurn();
                CurrentTurn = new Turn(this);
                CurrentControl = IsPlayerControl ? Goblin : Human;
                CurrentControl.BeginTurn(EmptyWish: !IsPlayerControl);
            }

            CurrentPhase = TurnPhase.New(PhaseType, this, CurrentTurn);
            CurrentPhase.Begin();
        }

        public RandomNumberGenerator Rng { get; private set; }

        public List<Territory> Territory { get; private set; }

        public Goblin Goblin { get; private set; }
        public Human Human { get; private set; }

        public TurnPhase CurrentPhase { get; private set; }
        public PhaseType PhaseType { get; private set; }
        public Faction CurrentControl { get; private set; }
        public bool IsPlayerControl { get; private set; }

        #region Turn
        public Turn CurrentTurn { get; private set; }

        #endregion Turn
    }

    public enum PhaseType
    {
        Begin,
        SelectEnemyTerritory,
        Mobilise,
        Settle,
        Reward,
        End,
    }
}
