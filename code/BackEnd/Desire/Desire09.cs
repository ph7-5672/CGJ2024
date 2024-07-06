namespace Cgj_2024.code.BackEnd
{
	/// <summary>
	/// 09 上一回合哥布林方没有损失任何领地
	/// </summary>
	internal class Desire09 : Desire
	{
		public override bool IsSatisefied()
		{
			// 如果当前回合是游戏的第一回合，则返回true
			// 否则获取上一回合人类方的行动信息，检查哥布林方防御是否成功
			// ...

			return base.IsSatisefied();
		}
	}
}
