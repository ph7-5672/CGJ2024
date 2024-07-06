using System.Collections.Generic;

namespace Cgj_2024.code.BackEnd.Phase
{
    public class MobilisePhase : TurnPhase
    {
        public override void Begin()
        {
            base.Begin();

            if (!IsPlayerContorl)
            {
                AIMobilize();
            }
        }

        public override void End()
        {
            base.End();
            Turn.AIMobilizedTribes = AIMobilizedTribes;
            Turn.PlayerMobilizedTribes = PlayerMobilizedTribes;
        }

        void AIMobilize()
        {
            var tribes = World.Human.Tribes;
            tribes.Sort((t1, t2) => t1.Troops.CompareTo(t2.Troops));
            int tot = 0;
            for (int i = 0;
                i < tribes.Count && tot < Turn.TargetedTerritory.Troops;
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
