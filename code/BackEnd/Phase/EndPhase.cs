﻿using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd.Phase
{
    public class EndPhase : RoundPhase
    {
        public override void Begin()
        {
            base.Begin();

            if (IsPlayerContorl)
            {
                SplitTribe(World.Goblin.Tribes);
            }
            else
            {
                SplitTribe(World.Human.Tribes);
            }
            World.NextPhase();
        }

        public override void End()
        {
            base.End();
        }

        void SplitTribe(List<Tribe> list)
        {
            Tribe newTribe = null;
            foreach (Tribe t in list)
            {
                if (t.Territory.Count > 1
                    && World.Rng.Randf() > Parameters.Instance.TribeSplitChance)
                {
                    var newSize = t.Territory.Count >> 1;
                    newTribe = new Tribe(World, t.Faction);

                    var territory = t.Territory;
                    t.Territory = territory[..newSize];
                    newTribe.Territory = territory[newSize..];
                    GD.Print($"分裂部落{t.Name} 领地:{string.Join(',', t.Territory.ToList())}, 新部落:{newTribe.Name} 领地:{string.Join(',', newTribe.Territory.ToList())}");
                    break;
                }
            }
            if (newTribe is not null)
            {
                list.Add(newTribe);
            }
        }
    }
}
