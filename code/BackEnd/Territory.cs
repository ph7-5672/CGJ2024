using Godot;
using System;
using System.Collections.Generic;

namespace Cgj_2024.code.BackEnd
{
	public class Territory
	{
		public Territory()
		{
			Name = GenerateRandomTerritoryName();
			while (usedTerritoryNames.Contains(Name))
			{
				Name = GenerateRandomTerritoryName();
			}

			usedTerritoryNames.Add(Name);

			GD.Print(Name);
		}

		string GenerateRandomTerritoryName()
		{
			var rand = new Random();
			return $"{territoryNamePrefixes[rand.Next(territoryNamePrefixes.Length)]}{territoryNameSuffixes[rand.Next(territoryNameSuffixes.Length)]}{territoryNameTypes[rand.Next(territoryNameTypes.Length)]}";
		}

		string[] territoryNamePrefixes = ["枫", "七", "冰", "饼", "妖", "弹", "双", "大", "小", "上"];
		string[] territoryNameSuffixes = ["石", "木", "牢", "猫", "狮", "田", "市", "宅", "岩", "波"];
		string[] territoryNameTypes = ["原", "岭", "村", "镇", "城", "堡", "岛", "山", "林", "关"];

		static HashSet<string> usedTerritoryNames = new HashSet<string>();

		public string Name { get; set; }
		public Tribe Tribe { get; set; }

		public int Treasure {  get; set; }
		public int Troops { get; set; }
		public int Size { get; set; }
	}
}
