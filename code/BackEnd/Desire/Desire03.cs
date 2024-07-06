using System.Linq;

namespace Cgj_2024.code.BackEnd
{
	/// <summary>
	/// 03 领地数量最多
	/// </summary>
	public class Desire03 : Desire
	{
		public Desire03(Tribe tribe)
			: base(tribe)
		{
		}

		public override bool IsSatisefied()
		{
			// 如果当前回合是游戏的第一回合，则返回true
			// 否则检查部落领地数量是否为最多

			var result = false;
			var lastTurn = Tribe.Faction.World.LastTurn;
			if (lastTurn == null)
			{
				result = true;
			}
			else
			{
				var allTribes = Tribe.Faction.Tribes;
				result = Tribe.Territory.Count == allTribes.Max(tribe => tribe.Territory.Count);
			}

			return result;
		}
	}
}
