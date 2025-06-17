using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class EnemyIdleState : BaseState
{
    public EnemyIdleState(Character c, StateManager m) : base(c, m) { }


    public override void EnterState()
    {
        Enemy mine = (Enemy)me;
        mine.GetAnimator().Play("Idle");
    }

    public override void ExitState()
    {
    }

    public override void UpdateState(Character target)
    {
        Enemy mine = (Enemy)me;
        if (mine.isActive)
        {
            manager.ChangeState(new EnemyWalkState(me, manager));
        }
    }
}
