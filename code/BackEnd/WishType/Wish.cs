using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd.WishType
{
    public class Wish
    {
        public static Wish New(Tribe tribe)
        {
            // todo: randomize here
            return new Wish();
        }
        public virtual bool IsSatisefied()
        {
            return false;
        }
        public Tribe Tribe { get; private set; }
    }

    public class EmptyWish : Wish
    {
        public override bool IsSatisefied() => true;
    }
}
