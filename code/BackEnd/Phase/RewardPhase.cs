using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd.Phase
{
    public class RewardPhase : RoundPhase
    {
        public override void Begin()
        {
            base.Begin();
            Treasure = Turn.CurrentRound.TargetedTerritory.Treasure;
            if (!IsPlayerContorl)
            {
                HandleDefence(Turn.BattleResult);
            }
        }

        public override void End()
        {
            if (IsPlayerContorl)
            {
                // Todo: 解注释这行开启额外特性
                // 封赏新领地后增加欲望
                //TerritoryRewaredTribe?.MakeADesire();
                if (TreasureRewaredTribes is not null)
                    foreach (var (tribe, treasure) in TreasureRewaredTribes)
                    {
                        tribe.RewardTreasure(treasure);
                    }
            }
            base.End();
        }

        void HandleDefence(bool win)
        {
            if (!win)
            {
                World.Human.Tribes.Sort((t1, t2) => t1.Territory.Count.CompareTo(t2.Territory.Count));
                Turn.TerritoryRewaredTribeHuman = World.Human.Tribes.First();
            }
        }

        public Dictionary<Tribe, int> TreasureRewaredTribes { get; set; }
        public int Treasure { get; private set; }
    }
}
