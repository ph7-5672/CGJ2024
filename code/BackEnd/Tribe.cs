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
                CanBeMobilized = true;
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
        public Wish Wish { get; protected set; }
        public List<Territory> Territory { get; protected set; } = [];

        public int Troops => Territory.Sum(t => t.Troops);

        public bool IsMobilized { get; protected set; } = false;
        public bool CanBeMobilized { get; protected set; }
    }
}
