using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{

    public abstract class State
    {
        //you can add a scriptableObject so that you can change the values(jumpForce...)
        protected Character character;
        protected StateMashine stateMashine;
        protected State(Character character, StateMashine stateMashine)
        {
            this.stateMashine = stateMashine;
            this.character = character;
        }
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void HandleInput() { }
        public virtual void LogicUpdate() { }
        public virtual void PhisicsUpdate() { }
    }
}
