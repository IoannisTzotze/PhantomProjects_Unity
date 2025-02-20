using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2_PlayerDetectedState : PlayerDetectedState
{
    protected B2_Fetiddeviation boss;
    bool minionsDead;

    public B2_PlayerDetectedState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_PlayerDetectedState stateData, B2_Fetiddeviation boss) : base(stateMachine, entity, animBoolName, stateData)
    {
        this.boss = boss;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        minionsDead = boss.minionsDead;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!minionsDead)
        {
            if (performCloseRangeAction)
            {
                stateMachine.ChangeState(boss.meleeAttackState);
            }
            else if (!isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(boss.lookForPlayerState);
            }
        }
        else if(minionsDead)
        {
            if (performCloseRangeAction)
            {
                stateMachine.ChangeState(boss.meleeAttackState);
            }
            else if (performLongRangeAction)
            {
                stateMachine.ChangeState(boss.chargeState);
            }
            else if (!isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(boss.lookForPlayerState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
