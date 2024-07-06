using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd.Phase
{
    public class RewardPhase : TurnPhase
    {
        public override void Begin()
        {
            base.Begin();
            Treasure = Turn.TargetedTerritory.Treasure;
            if (!IsPlayerContorl)
            {
                HandleDefence(Turn.BattleResult);
            }
        }

        public override void End()
        {
            if (IsPlayerContorl)
            {
                TerritoryRewaredTribe?.MakeADesire();
            }
            base.End();
        }

        void HandleDefence(bool win)
        {
            if (!win)
            {
                World.Human.Tribes.Sort((t1, t2) => t1.Territory.Count.CompareTo(t2.Territory.Count));
                Turn.TerritoryRewaredTribe = World.Human.Tribes.First();
            }
        }

        public Tribe TerritoryRewaredTribe { get; set; }

        public Dictionary<Tribe, int> TreasureRewaredTribes { get; set; }
        public int Treasure { get; private set; }
    }
}
