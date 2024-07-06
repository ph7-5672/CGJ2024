using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.Data
{
    public class Wish
    {
        public WishType WishType { get; set; }
        public int Count { get; set; }
    }

    public enum WishType { }
}
