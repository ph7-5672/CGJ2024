using System.Linq;

namespace Cgj_2024.code.BackEnd
{
	/// <summary>
	/// 01 领地总财宝最多
	/// </summary>
	public class Desire01 : Desire
	{
		public Desire01(Tribe tribe)
			: base(tribe)
		{
		}

		public override bool IsSatisefied()
		{
			// 如果当前回合是游戏的第一回合，则返回true
			// 否则检查部落总财宝是否为最多

			var result = false;
			var lastTurn = Tribe.Faction.World.LastTurn;
			if (lastTurn == null)
			{
				result = true;
			}
			else
			{
				var allTribes = Tribe.Faction.Tribes;
				result = Tribe.Treasure == allTribes.Max(tribe => tribe.Treasure);
			}

			return result;
		}
	}
}
