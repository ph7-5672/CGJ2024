using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd.WishType
{
    public abstract class Wish
    {
        public static Wish New(Tribe tribe)
        {
            // todo: randomize here
            var wish = new EmptyWish();
            wish.Tribe = tribe;
            return wish;
        }
        public virtual bool IsSatisefied() => false;
        public Tribe Tribe { get; private set; }
    }

    public class EmptyWish : Wish
    {
        public override bool IsSatisefied() => true;
    }
}
