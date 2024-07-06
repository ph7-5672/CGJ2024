namespace Cgj_2024.code.BackEnd
{
	/// <summary>
	/// 11 上一回合本部落的领地没有受到人类进攻，或成功防御了人类进攻
	/// </summary>
	internal class Desire11 : Desire
	{
		public Desire11(Tribe tribe)
			: base(tribe)
		{
		}

		public override bool IsSatisefied()
		{
			// 如果当前回合是游戏的第一回合，则返回true
			// 否则获取上一回合人类方的行动信息，检查本部落的领地没有受到进攻
			// 或者本部落领地受到进攻且哥布林方防御成功

			var result = false;
			var lastTurn = Tribe.Faction.World.LastTurn;
			if (lastTurn == null)
			{
				result = true;
			}
			else
			{
				var lastAIRound = lastTurn.AIRound;
				result = !Tribe.Territory.Contains(lastAIRound.TargetedTerritory)
					|| lastAIRound.BattleResult;
			}

			return result;
		}
	}
}
