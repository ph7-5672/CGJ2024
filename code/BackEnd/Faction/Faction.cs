using Godot;
using System.Collections.Generic;
using System.Linq;

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
			}
		}

        public virtual void EndTurn()
        {
            GD.Print($"{this} End Turn");

			foreach (var tribe in Tribes)
			{
				if (tribe.Territory.Count == 0)
				{
					GD.Print($"因为没有领地，{tribe.Name} 已死亡");
                    Tribes.Remove(tribe);
                }
			}
        }

		public virtual void Initialze(int tribeCount, RandomNumberGenerator rng, Parameters parameters)
		{
			for (var i = 0; i < tribeCount; i++)
			{
				var tribe = new Tribe(World, this);
				Tribes.Add(tribe);
				tribe.Initialize(rng, parameters);
			}
		}

		public IEnumerable<Tribe> GetOtherTribes(Tribe tribe)
		{
			return Tribes.Except([tribe]);
		}

		public List<Tribe> Tribes { get; private set; } = new List<Tribe>();
		public IEnumerable<Territory> Territories => Tribes.SelectMany(t => t.Territory);
		public World World { get; private set; }
	}
}
