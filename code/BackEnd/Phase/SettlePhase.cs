using Cgj_2024.code.BackEnd.Factions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd.Phase
{
    public class SettlePhase : RoundPhase
    {
        public override void Begin()
        {
            base.Begin();

            Turn.BattleResult = Turn.PlayerMobilizedTribes.Sum(t => t.Troops)
                > Turn.AIMobilizedTribes.Sum(t => t.Troops);
        }

        public override void End()
        {
            base.End();

            if (IsPlayerContorl)
            {
                HandleAttack(Turn.BattleResult);
            }
            else
            {
                HandleDefence(Turn.BattleResult);
            }
        }

        void HandleAttack(bool win) {
            if (win)
            {
                var territory = Turn.TargetedTerritory;
                var tribe = territory.Tribe;
                if (tribe.Territory.Count == 1)
                {
                    World.Human.Tribes.Remove(tribe);
                }
            }
        }
        void HandleDefence(bool win) {
            if (!win)
            {
                var territory = Turn.TargetedTerritory;
                var tribe = territory.Tribe;
                if(tribe.Territory.Count == 1)
                {
                    World.Goblin.Tribes.Remove(tribe);
                }
            }
        }
    }
}
