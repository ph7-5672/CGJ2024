using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd
{
	public abstract class Desire
	{
		public static Desire New(Tribe tribe)
		{
			var maker = makers[(int)(tribe.World.Rng.Randi() % makers.Count)];
			var d = maker();
			d.Tribe = tribe;
			return d;
		}

		static readonly List<Func<Desire>> makers =
		[
			() => new Desire01(),
			() => new Desire02(),
			() => new Desire03(),
			() => new Desire05(),
			() => new Desire06(),
			() => new Desire07(),
			() => new Desire08(),
			() => new Desire09(),
			() => new Desire10(),
			() => new Desire11(),
			() => new Desire12(),
		];

		public virtual bool IsSatisefied() => false;
		public Tribe Tribe { get; private set; }
	}
}
