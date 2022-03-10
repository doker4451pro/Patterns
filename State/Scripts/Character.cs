using StatePattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public IdleState IdleState { get; private set; }
    public JumpState jumpState { get; private set; }

    private StateMashine stateMashine;
    // Start is called before the first frame update
    void Start()
    {
        stateMashine = new StateMashine();
        IdleState = new IdleState(this, stateMashine);
        jumpState = new JumpState(this, stateMashine);
        stateMashine.Initialize(IdleState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMashine.CurrentState.HandleInput();

        stateMashine.CurrentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        stateMashine.CurrentState.PhisicsUpdate();
    }
}
