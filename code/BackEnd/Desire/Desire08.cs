namespace Cgj_2024.code.BackEnd
{
	/// <summary>
	/// 08 上一回合参加战争并成功征服人类领地，或上一回合没有被动员
	/// </summary>
	public class Desire08 : Desire
	{
		public Desire08(Tribe tribe)
			: base(tribe)
		{
		}

		public override bool IsSatisefied()
		{
			// 如果当前回合是游戏的第一回合，则返回true
			// 否则获取上一回合哥布林方的行动信息，检查部落是否被动员且进攻成功，或部落没有被动员
			// ...

			return base.IsSatisefied();
		}
	}
}
