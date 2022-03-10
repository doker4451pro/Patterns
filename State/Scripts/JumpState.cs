using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace StatePattern
{
    public class JumpState : State
    {
        private bool isGrounded;
        private Rigidbody rigidbody;
        public JumpState(Character character, StateMashine stateMashine) : base(character, stateMashine) 
        {
            rigidbody = character.GetComponent<Rigidbody>();
        }

        public override void Enter()
        {
            isGrounded = false;
            Jump();
        }

        private void Jump()
        {
            rigidbody.AddForce(Vector3.up);
        }

        public override void LogicUpdate()
        {
            if (isGrounded)
                stateMashine.ChangeState(character.IdleState);
        }
        public override void PhisicsUpdate()
        {
            isGrounded = Physics.OverlapSphere(character.transform.position, 0.5f).Length > 0;
        }
    }
}
