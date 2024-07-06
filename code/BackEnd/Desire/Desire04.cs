namespace Cgj_2024.code.BackEnd
{
	/// <summary>
	/// 04 领地数量多于某个其他部落
	/// </summary>
	public class Desire04 : Desire
	{
		public Desire04(Tribe tribe)
			: base(tribe)
		{
			// 随机选择一个其他部落作为比较目标
		}

		readonly Tribe compareTargetTribe;

		public override bool IsSatisefied()
		{
			// 如果当前回合是游戏的第一回合，则返回true
			// 否则检查部落领地数量是否大于比较目标部落的领地数量
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
