using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd.Factions
{
    public class Faction
    {
        public Faction(World world)
        {
            World = world;
        }
        public virtual void BeginTurn(bool EmptyWish = false)
        {
            GD.Print($"{this} Begin Turn");
            foreach (var tribe in Tribes)
            {
                tribe.BeginTurn(EmptyWish);
                if (World.LastTurn is null)
                {
                    tribe.MakeADesire();
                }
            }
        }

        public virtual void EndTurn()
        {
            GD.Print($"{this} End Turn");
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
                var tribe = new Tribe(World, this);
                tribe.Territory.Add(territories[i]);
                territories[i].Tribe = tribe;
                Tribes.Add(tribe);
            }
        }

        public List<Tribe> Tribes { get; private set; }
        public IEnumerable<Territory> Territories => Tribes.SelectMany(t => t.Territory);
        public World World { get; private set; }
    }
}
