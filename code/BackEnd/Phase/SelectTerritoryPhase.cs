﻿using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd.Phase
{
    public class SelectTerritoryPhase : TurnPhase
    {
        public override void Begin()
        {
            base.Begin();

            if (!IsPlayerContorl)
            {
                var t = World.Goblin.Territories;
                SeletecedTerritory = t.ElementAt((int)(World.Rng.Randi() % t.Count()));
            }
        }

        public override void End()
        {
            base.End();

            Turn.TargetedTerritory = SeletecedTerritory;
        }

        public Territory SeletecedTerritory { get; set; }
    }
}