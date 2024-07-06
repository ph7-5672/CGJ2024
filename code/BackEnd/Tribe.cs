using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.Data
{
    public class Tribe
    {
        public virtual void BeginTurn()
        {

        }

        public virtual void EndTurn()
        {

        }

        public string Name { get; set; }
        public List<Territory> Territory { get; private set; } = [];

        public Wish Wish { get; set; }

        public int Troops => Territory.Sum(t => t.Troops);
    }
}
