﻿namespace Cgj_2024.code.BackEnd
{
	/// <summary>
	/// 07 上一回合被赏赐了领地
	/// </summary>
	public class Desire07 : Desire
	{
		public override bool IsSatisefied()
		{
			// 如果当前回合是游戏的第一回合，则返回true
			// 否则获取上一回合哥布林方的行动信息，检查部落是否被赏赐领地
			// ...

			return base.IsSatisefied();
		}
	}
}