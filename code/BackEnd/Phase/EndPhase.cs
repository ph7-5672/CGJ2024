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
        }

        public override void End()
        {
            base.End();
        }

        void SplitTribe(IList<Tribe> list)
        {
            var newList = new List<Tribe>();
            foreach (Tribe t in list)
            {
                if (t.Territory.Count > 1
                    && World.Rng.Randf() > Parameters.Instance.TribeSplitChance)
                {
                    var newSize = t.Territory.Count >> 1;
                    var tribe = new Tribe(World, t.Faction);

                    var territory = t.Territory;
                    t.Territory = territory[..newSize];
                    tribe.Territory = territory[newSize..];
                    newList.Add(tribe);
                }
            }

            foreach (var item in newList)
            {
                list.Add(item);
            }
        }
    }
}
