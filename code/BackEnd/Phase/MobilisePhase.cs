using System.Collections.Generic;
using System.Linq;

namespace Cgj_2024.code.BackEnd.Phase
{
    public class MobilisePhase : RoundPhase
    {
        public override void Begin()
        {
            base.Begin();

            if (!IsPlayerContorl)
            {
                AIMobilize();
            }
            else
            {
                //debug
                if (Turn.CurrentRound.TargetedTerritory is null)
                {
                    Turn.CurrentRound.TargetedTerritory = World.Human.Territories.First();
                }

                AIMobilizedTribes = [Turn.CurrentRound.TargetedTerritory.Tribe];
            }
        }

        public override void End()
        {
            base.End();
            Turn.CurrentRound.AIMobilizedTribes = AIMobilizedTribes;
            Turn.CurrentRound.PlayerMobilizedTribes = PlayerMobilizedTribes;
        }

        void AIMobilize()
        {
            var tribes = World.Human.Tribes;
            tribes.Sort((t1, t2) => t1.Troops.CompareTo(t2.Troops));
            int tot = 0;
            for (int i = 0;
                i < tribes.Count && tot < Turn.CurrentRound.TargetedTerritory.Troops;
                i++)
            {
                tot += tribes[i].Troops;
                AIMobilizedTribes.Add(tribes[i]);
            }
        }

        public List<Tribe> PlayerMobilizedTribes = [];
        public List<Tribe> AIMobilizedTribes = [];
    }
}
