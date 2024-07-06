namespace Cgj_2024.code.BackEnd
{
	/// <summary>
	/// 09 上一回合哥布林方没有损失任何领地
	/// </summary>
	internal class Desire09 : Desire
	{
		public Desire09(Tribe tribe)
			: base(tribe)
		{
		}

		public override bool IsSatisefied()
		{
			// 如果当前回合是游戏的第一回合，则返回true
			// 否则获取上一回合人类方的行动信息，检查哥布林方防御是否成功

			var result = false;
			var lastTurn = Tribe.Faction.World.LastTurn;
			if (lastTurn == null)
			{
				result = true;
			}
			else
			{
				result = lastTurn.AIRound.BattleResult;
			}

			return result;
		}

		public override string Description => "领地总财宝最多";
	}
}
