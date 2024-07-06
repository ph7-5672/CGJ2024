using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cgj_2024.code.BackEnd
{
    public partial class Parameters : Node
    {
        [ExportGroup("World")]
        [Export] public int Seed;
        [Export] public int WorldSize;

        [ExportGroup("Territory")]
        [Export] public int TreasureMin = 1;
        [Export] public int TreasureMax = 5;

        [Export] public int TroopMin = 1;
        [Export] public int TroopMax = 5;

        [Export] public int SizeMin = 1;
        [Export] public int SizeMax = 5;

        [Export] public float TribeSplitChance = 0.4f;


        public override void _EnterTree()
        {
            base._EnterTree();
            Instance = this;
        }

        public override void _ExitTree()
        {
            Instance = null;
            base._ExitTree();
        }

        public static Parameters Instance { get; private set; }
    }
}
