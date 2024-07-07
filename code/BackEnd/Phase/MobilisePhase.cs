using Godot;
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
                AIMobilizedTribes = [Turn.CurrentRound.TargetedTerritory.Tribe];
            }
        }

        public override void End()
        {
            base.End();
            Turn.CurrentRound.AIMobilizedTribes = AIMobilizedTribes;
            Turn.CurrentRound.PlayerMobilizedTribes = PlayerMobilizedTribes;

            PlayerMobilizedTribes.ForEach(t => t.IsMobilized = true);
        }

        void AIMobilize()
        {
            var tribes = World.Human.Tribes;
            tribes.Sort((t1, t2) => t1.Troops.CompareTo(t2.Troops));
            int tot = 0;
            for (int i = 0;
                i < tribes.Count && tot < Turn.CurrentRound.TargetedTerritory.Tribe.Troops;
                i++)
            {
                tot += tribes[i].Troops;
                AIMobilizedTribes.Add(tribes[i]);
            }

            var TargetedTerritory = Turn.CurrentRound.TargetedTerritory;
            Turn.CurrentRound.AIMobilizedTribes = AIMobilizedTribes;
            GD.Print($"AI 进攻{TargetedTerritory.Name}领地， 目标领地 部落：{TargetedTerritory.Tribe.Name}, 兵力：{TargetedTerritory.Tribe.Troops}， 人类兵力：{AIMobilizedTribes.Sum(t => t.Troops)}");
        }

        public List<Tribe> PlayerMobilizedTribes = [];
        public List<Tribe> AIMobilizedTribes = [];
    }
}
