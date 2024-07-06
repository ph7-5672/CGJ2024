using System;
using System.Collections.Generic;
using System.Linq;
using Cgj_2024.code.BackEnd.WishType;

namespace Cgj_2024.code.BackEnd
{
    public class Tribe
    {
        public virtual void BeginTurn(bool emptyWish)
        {
            if (emptyWish)
            {
                Wish = new EmptyWish();
            }
            else
            {
                Wish = Wish.New(this);
            }
        }

        public virtual void EndTurn()
        {
            IsMobilized = false;
        }

        public string Name { get; set; }
        public Wish Wish { get; private set; }
        public List<Territory> Territory { get; private set; } = [];

        public int Troops => Territory.Sum(t => t.Troops);

        public bool IsMobilized { get; private set; } = false;
        public bool CanBeMobilized => Wish.IsSatisefied();
    }
}
