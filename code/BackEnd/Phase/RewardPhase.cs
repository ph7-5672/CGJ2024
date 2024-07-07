using Godot;
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
                HandleDefence(Turn.CurrentRound.BattleResult);
                World.NextPhase();
            }
            else if (IsPlayerContorl && !Turn.CurrentRound.BattleResult)
            {
                World.NextPhase();
            }
        }

        public override void End()
        {
            if (IsPlayerContorl && Turn.CurrentRound.BattleResult)
            {
                // Todo: 解注释这行开启额外特性
                // 封赏新领地后增加欲望
                //TerritoryRewaredTribe?.MakeADesire();
                if (TreasureRewaredTribes is not null)
                    foreach (var (tribe, treasure) in TreasureRewaredTribes)
                    {
                        tribe.RewardTreasure(treasure);
                    }
                GiveTerritory(Turn.TerritoryRewaredTribeGoblin, Turn.CurrentRound.TargetedTerritory);
            }
            else if (!IsPlayerContorl && !Turn.CurrentRound.BattleResult)
            {
                GiveTerritory(Turn.TerritoryRewaredTribeHuman, Turn.CurrentRound.TargetedTerritory);
            }


            //Turn.TreasureRewaredTribes = TreasureRewaredTribes;
            base.End();
        }

        void GiveTerritory(Tribe tribe, Territory territory)
        {
            if (tribe is null || territory is null) {
                GD.Print($"本轮没有封赏！ 部落：{tribe?.Name} 领地:{territory?.Name}");
                return;
            }
            GD.Print($"领地{territory.Name}从{territory.Tribe.Name}分给了{tribe.Name}");
            territory.Tribe.Territory.Remove(territory);
            territory.Tribe = tribe;
            tribe.Territory.Add(territory);
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
