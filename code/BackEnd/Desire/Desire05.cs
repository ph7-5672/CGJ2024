namespace Cgj_2024.code.BackEnd
{
	/// <summary>
	/// 05 上一回合被赏赐了财宝
	/// </summary>
	public class Desire05 : Desire
	{
		public Desire05(Tribe tribe)
			: base(tribe)
		{
		}

		public override bool IsSatisefied()
		{
			// 如果当前回合是游戏的第一回合，则返回true
			// 否则获取上一回合哥布林方的行动信息，检查部落是否被赏赐财宝
			// ...

			var result = false;
			var lastTurn = Tribe.Faction.World.LastTurn;
			if (lastTurn == null)
			{
				result = true;
			}

			return result;
		}
	}
}
