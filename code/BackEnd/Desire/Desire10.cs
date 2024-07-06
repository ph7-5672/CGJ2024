namespace Cgj_2024.code.BackEnd
{
	/// <summary>
	/// 10 上一回合本部落的领地没有受到人类进攻
	/// </summary>
	public class Desire10 : Desire
	{
		public Desire10(Tribe tribe)
			: base(tribe)
		{
		}

		public override bool IsSatisefied()
		{
			// 如果当前回合是游戏的第一回合，则返回true
			// 否则获取上一回合人类方的行动信息，检查本部落的领地没有受到进攻

			var result = false;
			var lastTurn = Tribe.Faction.World.LastTurn;
			if (lastTurn == null)
			{
				result = true;
			}
			else
			{
				result = !Tribe.Territory.Contains(lastTurn.AIRound.TargetedTerritory);
			}

			return result;
		}
	}
}
