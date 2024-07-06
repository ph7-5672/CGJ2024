using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd
{
    public class Territory
    {
        public string Name { get; set; }
        public Tribe Tribe { get; set; }

        public int Treasure {  get; set; }
        public int Troops { get; set; }
        public int Size { get; set; }
    }
}
