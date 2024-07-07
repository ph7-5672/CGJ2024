using System.Linq;

namespace Cgj_2024.code.BackEnd
{
	/// <summary>
	/// 06 上一回合被赏赐了最多财宝
	/// </summary>
	public class Desire06 : Desire
	{
		public Desire06(Tribe tribe)
			: base(tribe)
		{
		}

		public override bool IsSatisefied()
		{
			// 如果当前回合是游戏的第一回合，则返回true
			// 否则获取上一回合哥布林方的行动信息，检查部落是否被赏赐最多财宝

			var result = false;
			var lastTurn = Tribe.Faction.World.LastTurn;
			if (lastTurn == null)
			{
				result = true;
			}
			else
			{
				if (lastTurn.TreasureRewaredTribes?.TryGetValue(Tribe, out var rewardedTreasure) ?? false)
				{
					result = rewardedTreasure == lastTurn.TreasureRewaredTribes.Max(tribe => tribe.Value);
				}
			}

			return result;
		}

		public override string Description => "上回合被赏赐最多";
	}
}
