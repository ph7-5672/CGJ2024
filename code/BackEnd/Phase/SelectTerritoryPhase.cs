using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd.Phase
{
    public class SelectTerritoryPhase : RoundPhase
    {
        public override void Begin()
        {
            base.Begin();

            if (!IsPlayerContorl)
            {
                var t = World.Goblin.Territories;
                SeletecedTerritory = t.ElementAt((int)(World.Rng.Randi() % t.Count()));
                Turn.CurrentRound.TargetedTerritory = SeletecedTerritory;
                GD.Print($"AI 选择了\"{SeletecedTerritory.Name}\"进攻！{SeletecedTerritory.Tribe.Name} {SeletecedTerritory.Tribe.Faction}");
            }
        }

        public override void End()
        {
            base.End();

            Turn.CurrentRound.TargetedTerritory = SeletecedTerritory;
            var targeted = Turn.CurrentRound.TargetedTerritory;
            GD.Print($"选择了\"{targeted?.Name}\"进攻 目标信息:{targeted?.Tribe.Name}, {targeted.Tribe.Troops}");
        }

        public Territory SeletecedTerritory { get; set; }
    }
}
