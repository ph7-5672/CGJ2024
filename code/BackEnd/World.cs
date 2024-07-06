using Cgj_2024.code.Data;
using Cgj_2024.code.Data.Role;
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

        public void Initialzize()
        {
            PhaseType = PhaseType.Begin;
            CurrentPhase = TurnPhase.New(PhaseType);
            IsPlayerControl = true;

            Rng.Seed = (ulong)Parameters.Instance.Seed;

            for (int i = 0; i < Parameters.Instance.WorldSize; i++)
            {
                var territory = new Territory();
                territory.Troops = Rng.RandiRange(Parameters.Instance.TroopMin, Parameters.Instance.TroopMax);
                territory.Treasure = Rng.RandiRange(Parameters.Instance.TreasureMin, Parameters.Instance.TreasureMax);
                Territory.Add(territory);
            }

            int size = Territory.Count >> 1;
            Goblin.Initialze(Territory[..size]);
            Human.Initialze(Territory[size..]);
        }

        public void NextPhase()
        {
            if (PhaseType != PhaseType.End)
            {
                PhaseType++;
            }
            else
            {
                PhaseType = PhaseType.Begin;
                IsPlayerControl = !IsPlayerControl;
            }

            CurrentPhase.End(IsPlayerControl);
            GD.Print($"{CurrentPhase} End");
            CurrentPhase = TurnPhase.New(PhaseType);
            GD.Print($"{CurrentPhase} Begin");
            CurrentPhase.Begin(IsPlayerControl);
        }

        public RandomNumberGenerator Rng {  get; private set; }

        public List<Territory> Territory { get; private set; }

        public Goblin Goblin { get; private set; }
        public Human Human { get; private set; }

        public TurnPhase CurrentPhase { get; private set; }
        public PhaseType PhaseType { get; private set; }
        public bool IsPlayerControl = true;
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
