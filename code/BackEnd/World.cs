using Cgj_2024.code.Data;
using Cgj_2024.code.Data.Role;
using System.Collections.Generic;
using Godot;

namespace Cgj_2024.code.BackEnd
{
    public class World
    {
        public World(ulong seed, int worldSize) {
            Rng = new RandomNumberGenerator
            {
                Seed = seed
            };

            Territory = new List<Territory>(worldSize);
            Goblin = new Goblin();
            Human = new Human();
        }

        public void Initialzize(int worldSize)
        {
            
        }

        public RandomNumberGenerator Rng {  get; private set; }

        public List<Territory> Territory { get; private set; }

        public Goblin Goblin { get; private set; }
        public Human Human { get; private set; }
    }
}
