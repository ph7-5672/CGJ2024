/*
 * 在这里控制游戏流程。
 */

using Godot;

namespace Cgj_2024.code;

public partial class Game : Node2D
{ 
    public static Game Instance { get; private set; }

    public override void _EnterTree()
    {
        Instance = this;
        ChangeState(State.Preloading);

        EnterTree_State();
        EnterTree_UI();
    }

    void EnterState(State state)
    {
        switch (state)
        {
            case State.None:
                break;
            case State.Preloading:
                break;
            case State.Menu:
                break;
        }
    }

    void ExitState(State state)
    {
        switch (state)
        {
            case State.None:
                break;
            case State.Preloading:
                break;
            case State.Menu:
                break;
        }
    }


}
