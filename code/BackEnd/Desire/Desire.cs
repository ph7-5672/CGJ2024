using System;
using System.Collections.Generic;

namespace Cgj_2024.code.BackEnd
{
	public abstract class Desire
	{
		public static Desire New(Tribe tribe)
		{
			var maker = makers[(int)(tribe.World.Rng.Randi() % makers.Count)];
			var d = maker(tribe);
			return d;
		}

		static readonly List<Func<Tribe, Desire>> makers =
		[
			(tribe) => new Desire01(tribe),
			(tribe) => new Desire02(tribe),
			(tribe) => new Desire03(tribe),
			(tribe) => new Desire04(tribe),
			(tribe) => new Desire05(tribe),
			(tribe) => new Desire06(tribe),
			(tribe) => new Desire07(tribe),
			(tribe) => new Desire08(tribe),
			(tribe) => new Desire09(tribe),
			(tribe) => new Desire10(tribe),
			(tribe) => new Desire11(tribe),
			(tribe) => new Desire12(tribe),
		];

		public Desire(Tribe tribe)
		{
			Tribe = tribe;
		}

		public virtual bool IsSatisefied() => false;
		public Tribe Tribe { get; }
		public abstract string Description { get; }
	}
}
