namespace Cgj_2024.code.BackEnd
{
	/// <summary>
	/// 02 领地总财宝多于某个其他部落
	/// </summary>
	public class Desire02 : Desire
	{
		public Desire02()
		{
			// 随机选择一个其他部落作为比较目标
		}

		readonly Tribe compareTargetTribe;

		public override bool IsSatisefied()
		{
			// 如果当前回合是游戏的第一回合，则返回true
			// 否则检查部落总财宝是否大于比较目标部落的总财宝
			// ...

			return base.IsSatisefied();
		}
	}
}
