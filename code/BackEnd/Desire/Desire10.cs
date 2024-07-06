namespace Cgj_2024.code.BackEnd
{
	/// <summary>
	/// 10 上一回合本部落的领地没有受到人类进攻
	/// </summary>
	public class Desire10 : Desire
	{
		public override bool IsSatisefied()
		{
			var result = false;
			var lastTurn = Tribe.Faction.World.LastTurn;
			if (lastTurn == null)
			{
				result = true;
			}
			else
			{
				result = !Tribe.Territory.Contains(lastTurn.TargetedTerritory);
			}

			return result;
		}
	}
}
