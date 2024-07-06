using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd.Factions
{
    public class Human : Faction
    {
        public override void BeginTurn(bool emptyWish)
        {
            base.BeginTurn(emptyWish);
            foreach (var tribe in Tribes)
            {
                tribe.BeginTurn(true);
            }
        }
    }
}
