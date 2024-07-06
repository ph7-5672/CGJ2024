﻿using System;
using System.Linq;

namespace Cgj_2024.code.BackEnd
{
	/// <summary>
	/// 02 领地总收入多于某个其他部落
	/// </summary>
	public class Desire02 : Desire
	{
		public Desire02(Tribe tribe)
			: base(tribe)
		{
			// 随机选择一个其他部落作为比较目标
			var rand = new Random();
			var allOtherTribes = Tribe.Faction.GetOtherTribes(Tribe);
			compareTargetTribe = allOtherTribes.ElementAt(rand.Next(allOtherTribes.Count()));
		}

		readonly Tribe compareTargetTribe;

		public override bool IsSatisefied()
		{
			// 如果当前回合是游戏的第一回合，则返回true
			// 否则检查部落总财宝是否大于比较目标部落的总财宝

			var result = false;
			var lastTurn = Tribe.Faction.World.LastTurn;
			if (lastTurn == null)
			{
				result = true;
			}
			else
			{
				result = Tribe.Treasure > compareTargetTribe.Treasure;
			}

			return result;
		}

		public override string Description => $"总收入超过{compareTargetTribe.Name}部落";
	}
}
