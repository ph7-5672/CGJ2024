using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd
{
    public class Turn
    {
        public Turn(World world)
        {
            World = world;
            IsPlayerContorl = world.IsPlayerControl;
        }

        public World World { get; private set; }

        public Territory TargetedTerritory { get; set; }

        public IList<Tribe> PlayerMobilizedTribes { get; set; }
        public IList<Tribe> AIMobilizedTribes { get; set; }

        public bool IsPlayerContorl { get; private set; }

        public bool BattleResult {  get; set; }
    }
}
