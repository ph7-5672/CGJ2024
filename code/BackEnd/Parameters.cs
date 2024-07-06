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
        [Export] public int TreasureMin;
        [Export] public int TreasureMax;

        [Export] public int TroopMin;
        [Export] public int TroopMax;


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
