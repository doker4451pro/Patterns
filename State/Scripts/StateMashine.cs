using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public class StateMashine
    {
        public State CurrentState { get; private set; }

        public void Initialize(State state)
        {
            CurrentState = state;
            state.Enter();
        }
        public void ChangeState(State newState)
        {
            CurrentState.Exit();

            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}
