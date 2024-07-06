namespace Cgj_2024.code.BackEnd
{
	/// <summary>
	/// 12 上一回合其他部落受到人类进攻
	/// </summary>
	public class Desire12 : Desire
	{
		public Desire12(Tribe tribe)
			: base(tribe)
		{
		}

		public override bool IsSatisefied()
		{
			// 如果当前回合是游戏的第一回合，则返回true
			// 否则获取上一回合人类方的行动信息，检查其他部落的领地受到进攻
			// ...

			return base.IsSatisefied();
		}
	}
}
