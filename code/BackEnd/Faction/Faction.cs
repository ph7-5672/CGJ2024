using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.Data.Role
{
    public class Faction
    {
        public virtual void BeginTurn()
        {
            foreach (var tribe in Tribes)
            {
                tribe.BeginTurn();
            }
        }

        public virtual void EndTurn()
        {
            foreach (var tribe in Tribes)
            {
                tribe.EndTurn();
            }
        }

        public virtual void Initialze(IList<Territory> territories)
        {
            Tribes = new List<Tribe>(territories.Count);
            for (int i = 0; i < territories.Count; i++)
            {
                var tribe = new Tribe();
                tribe.Territory.Add(territories[i]);
                Tribes.Add(tribe);
            }
        }

        public List<Tribe> Tribes { get; private set; }
        public IEnumerable<Territory> Territories => Tribes.SelectMany(t => t.Territory);
    }
}
