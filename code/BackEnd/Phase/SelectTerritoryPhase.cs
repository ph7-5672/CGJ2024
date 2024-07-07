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
            }
        }

        public override void End()
        {
            base.End();

            Turn.CurrentRound.TargetedTerritory = SeletecedTerritory;
        }

        public Territory SeletecedTerritory { get; set; }
    }
}
