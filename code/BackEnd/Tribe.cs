using System;
using System.Collections.Generic;
using System.Linq;
using Cgj_2024.code.BackEnd.Factions;
using Godot;

namespace Cgj_2024.code.BackEnd
{
	public class Tribe
    {
        public Tribe(World world, Faction faction)
        {
            World = world;
            Faction = faction;
            GenerateName();
        }

        public void Initialize(RandomNumberGenerator rng, Parameters parameters)
        {
            var territoryCount = rng.RandiRange(1, 2);
            for (var i = 0; i < territoryCount; i++)
            {
                var territory = new Territory
                {
                    Troops = rng.RandiRange(parameters.TroopMin, parameters.TroopMax),
                    Treasure = rng.RandiRange(parameters.TreasureMin, parameters.TreasureMax),
                    Size = rng.RandiRange(parameters.SizeMin, parameters.SizeMax),
                };
                Territory.Add(territory);
                territory.Tribe = this;
            }
        }

        void GenerateName()
        {
            if (Faction is Goblin)
            {
                Name = GenerateRandomGoblinTribeName();
                while (usedGoblinTribeNames.Contains(Name))
                {
                    Name = GenerateRandomGoblinTribeName();
                }

                usedGoblinTribeNames.Add(Name);
            }
            else if (Faction is Human)
            {
                Name = GenerateRandomHumanLordName();
                while (usedHumanLordNames.Contains(Name))
                {
                    Name = GenerateRandomHumanLordName();
                }

                usedHumanLordNames.Add(Name);
            }
        }

        string GenerateRandomGoblinTribeName()
        {
            var rand = new Random();
            return $"{goblinTribeNamePrefixes[rand.Next(goblinTribeNamePrefixes.Length)]}{goblinTribeNameSuffixes[rand.Next(goblinTribeNameSuffixes.Length)]}";
		}

		string[] goblinTribeNamePrefixes = ["毒", "恶", "尖", "大", "滑", "泥", "臭", "绿", "小", "邪"];
        string[] goblinTribeNameSuffixes = ["骨", "锤", "狼", "棒", "蛇", "猪", "脚", "矛", "皮", "头"];

		static HashSet<string> usedGoblinTribeNames = new HashSet<string>();

		string GenerateRandomHumanLordName()
        {
            var rand = new Random();
			return $"{humanLordNamePrefixes[rand.Next(humanLordNamePrefixes.Length)]}{humanLordNameSuffixes[rand.Next(humanLordNameSuffixes.Length)]}";
		}

		string[] humanLordNamePrefixes = ["乔", "魏", "佩", "汤", "杰", "伊", "豪", "杜", "弗", "林"];
		string[] humanLordNameSuffixes = ["治", "廉", "琪", "姆", "克", "森", "斯", "宾", "浪", "肯"];

        static HashSet<string> usedHumanLordNames = new HashSet<string>();

		public virtual void BeginTurn(bool emptyWish)
        {
            IsMobilized = false;
        }

        public virtual void EndTurn()
        {
        }

        public virtual void MakeADesire()
        {
            Desires.Add(Desire.New(this));
        }

        public void RewardTreasure(int treasure)
        {
            TotalRewardedTreasure += treasure;
        }

        public string Name { get; set; }
        public List<Desire> Desires { get; protected set; } = [];
        public List<Territory> Territory { get; set; } = [];

        public int Troops => Territory.Sum(t => t.Troops);
        public int Treasure => Territory.Sum(t => t.Treasure);

        public int TotalRewardedTreasure { get; protected set; }

        public bool IsMobilized { get; protected set; } = false;
        public bool CanBeMobilized => !IsMobilized && DesireSatisefied;
        public bool DesireSatisefied => Desires.Count == 0 || Desires.TrueForAll(d => d.IsSatisefied());

        public World World { get; protected set; }
        public Faction Faction { get; protected set; }
    }
}
