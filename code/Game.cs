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
        // 各个模块的初始化。
        EnterTree_State();
        EnterTree_UI();

        ChangeState(State.Preloading);
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
