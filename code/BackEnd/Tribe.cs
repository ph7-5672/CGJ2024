using System;
using System.Collections.Generic;
using System.Linq;
using Cgj_2024.code.BackEnd.Factions;
using Cgj_2024.code.BackEnd.WishType;

namespace Cgj_2024.code.BackEnd
{
    public class Tribe
    {
        public Tribe(World world, Faction faction)
        {
            World = world;
            Faction = faction;
        }

        public virtual void BeginTurn(bool emptyWish)
        {
            IsMobilized = false;
        }

        public virtual void EndTurn()
        {
            IsMobilized = false;
        }

        public virtual void MakeADesire()
        {
            Desires.Add(Desire.New(this));
        }

        public string Name { get; set; }
        public List<Desire> Desires { get; protected set; } = [];
        public List<Territory> Territory { get; set; } = [];

        public int Troops => Territory.Sum(t => t.Troops);

        public bool IsMobilized { get; protected set; } = false;
        public bool CanBeMobilized => Desires.Count == 0 || Desires.TrueForAll(d => d.IsSatisefied());

        public World World { get; protected set; }
        public Faction Faction { get; protected set; }
    }
}
