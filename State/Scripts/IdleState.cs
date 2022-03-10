using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StatePattern
{
    public class IdleState:State
    {
        private bool jumping;
        public IdleState(Character character, StateMashine stateMashine) : base(character, stateMashine) { }

        public override void Enter()
        {
            jumping = false;
        }
        public override void HandleInput()
        {
            jumping = Input.GetKeyDown(KeyCode.Space);
        }
        public override void LogicUpdate()
        {
            if (jumping)
                stateMashine.ChangeState(character.jumpState);
        }
    }

}
