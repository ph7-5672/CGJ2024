using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd.Factions
{
    public class Goblin : Faction
    {
        public Goblin(World world) : base(world)
        {
        }

        public override void EndTurn()
        {
            base.EndTurn();

            foreach (var tribe in Tribes)
            {
                tribe.EndTurn();
            }
        }
    }
}
