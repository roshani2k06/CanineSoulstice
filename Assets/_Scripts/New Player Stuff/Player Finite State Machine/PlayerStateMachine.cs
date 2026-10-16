using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStateMachine 
{
    public PlayerState CurrentState { get; private set; }
    public string stateDebug;
    public void Initialize(PlayerState statrtingState)
    {
        CurrentState = statrtingState;
        CurrentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
        stateDebug = $"{ CurrentState}";
    }
}
