
/*
 * 游戏状态类。
 */

using System;

namespace Cgj_2024.code;


public partial class Game
{
    public event Action<State> StateEntered;

    public event Action<State> StateExited;

    public enum State
    { 
        None,
        Preloading,
        Menu,

    }

    public State CurrentState { get; private set; }

    void EnterTree_State()
    {
        StateEntered += EnterState;
        StateExited += ExitState;
    }

    public static void ChangeState(State state)
    {
        var current = Instance.CurrentState;
        if (current == state)
        {
            return;
        }

        Instance.StateExited(current);
        Instance.CurrentState = state;
        Instance.StateEntered(state);
    }


    


}
