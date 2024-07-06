using Cgj_2024.code.BackEnd.Phase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd
{
    public class Turn
    {
        public Turn(World world)
        {
            World = world;

            PlayerRound = new Round(world, world.Goblin, this);
            AIRound = new Round(world, world.Human, this);
            CurrentRound = PlayerRound;
        }

        public void Begin()
        {
            World.Goblin.BeginTurn();
            World.Human.BeginTurn();
            CurrentRound.Begin();
        }

        public void End()
        {
            CurrentRound.End();
            World.Goblin.EndTurn();
            World.Human.EndTurn();
        }

        /// <summary>
        /// Return <see langword="true"/> when proceed to next turn.
        /// </summary>
        /// <returns></returns>
        public bool Next()
        {
            bool nextTurn = false;

            var progress = CurrentRound.NextPhase();

            if (progress)
            {
                if (!IsPlayerContorl)
                {
                    nextTurn = true;
                }
                else
                {
                    CurrentRound.End();
                    CurrentRound = AIRound;
                    CurrentRound.Begin();
                }
            }

            return nextTurn;
        }

        public RoundPhase CurrentPhasse => CurrentRound.CurrentPhase;
        public Round CurrentRound { get; private set; }

        public Round PlayerRound { get; private set; }
        public Round AIRound { get; private set; }

        public World World { get; private set; }

        public Territory TargetedTerritory { get; set; }

        public IList<Tribe> PlayerMobilizedTribes { get; set; }
        public IList<Tribe> AIMobilizedTribes { get; set; }

        public bool IsPlayerContorl => CurrentRound == PlayerRound;

        public bool BattleResult { get; set; }

        public Tribe TerritoryRewaredTribe { get; set; }

        public Dictionary<Tribe, int> TreasureRewaredTribes { get; set; }
    }
}
