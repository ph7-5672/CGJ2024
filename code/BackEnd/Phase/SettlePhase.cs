﻿using Cgj_2024.code.BackEnd.Factions;
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

            Turn.CurrentRound.BattleResult = Turn.CurrentRound.PlayerMobilizedTribes.Sum(t => t.Troops)
                > Turn.CurrentRound.AIMobilizedTribes.Sum(t => t.Troops);
        }

        public override void End()
        {
            base.End();

            if (IsPlayerContorl)
            {
                HandleAttack(Turn.CurrentRound.BattleResult);
            }
            else
            {
                HandleDefence(Turn.CurrentRound.BattleResult);
            }
        }

        void HandleAttack(bool win) {
            if (win)
            {
                var territory = Turn.CurrentRound.TargetedTerritory;
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
                var territory = Turn.CurrentRound.TargetedTerritory;
                var tribe = territory.Tribe;
                if(tribe.Territory.Count == 1)
                {
                    World.Goblin.Tribes.Remove(tribe);
                }
            }
        }
    }
}
