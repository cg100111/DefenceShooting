using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager
{
    private BaseState state;

    public void ChangeState(BaseState newState)
    {
        if (state != null)
            state.ExitState();

        state = newState;
        state.EnterState();
    }
}
