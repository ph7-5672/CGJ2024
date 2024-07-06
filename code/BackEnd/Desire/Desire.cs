using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd.WishType
{
    public abstract class Desire
    {
        public static Desire New(Tribe tribe)
        {
            var maker = makers[(int)(tribe.World.Rng.Randi() % makers.Count)];
            var d = maker();
            d.Tribe = tribe;
            return d;
        }

        static readonly List<Func<Desire>> makers =
        [
            () => new MaxTerritory(),
        ];

        public virtual bool IsSatisefied() => false;
        public Tribe Tribe { get; private set; }
    }
}
