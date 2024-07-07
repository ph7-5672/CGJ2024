using Cgj_2024.code.BackEnd.Factions;
using Cgj_2024.code.BackEnd.Phase;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd
{
    public class Round
    {
        public Round(World world, Faction faction, Turn turn) {
            PhaseType = PhaseType.Begin;
            World = world;
            CurrentContorl = faction;
            Turn = turn;

            CurrentPhase = RoundPhase.New(PhaseType, World, Turn);
        }

        /// <summary>
        /// Return <see langword="true"/> when proceed to next phase.
        /// </summary>
        /// <returns></returns>
        public bool NextPhase()
        {
            bool nextRound = false;

            if (PhaseType != PhaseType.End)
            {
                PhaseType++;
            }
            else
            {
                PhaseType = PhaseType.Begin;
                nextRound = true;
            }

            if (nextRound)
            {
                return nextRound;
            }


            CurrentPhase.End();
            CurrentPhase = RoundPhase.New(PhaseType, World, Turn);
            CurrentPhase.Begin();
            
            return false;
        }

        public void Begin()
        {
            GD.Print($"{this} Begin Round");
            CurrentPhase.Begin();
        }

        internal void End()
        {
            CurrentPhase.End();
            GD.Print($"{this} End Round");
        }

        public Turn Turn { get; private set; }
        public World World { get; private set; }
        public Faction CurrentContorl { get; private set; }

        public bool BattleResult { get; set; }

        public Territory TargetedTerritory { get; set; }
        public IList<Tribe> PlayerMobilizedTribes { get; set; } = new List<Tribe>();
        public IList<Tribe> AIMobilizedTribes { get; set; } = new List<Tribe>();

        public PhaseType PhaseType { get; set; }
        public RoundPhase CurrentPhase { get; private set; }
    }

    public enum PhaseType
    {
        Begin,
        SelectEnemyTerritory,
        Mobilise,
        Settle,
        Reward,
        End,
        Win,
        Lose,
    }
}
