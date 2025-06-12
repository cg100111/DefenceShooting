using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState : BaseState
{
    public EnemyHurtState(Character c, StateManager m) : base(c, m) { }

    public override void EnterState()
    {
        Enemy mine = (Enemy)me;
        mine.GetAnimator().CrossFade("Get Hit", 0.1f);
    }

    public override void ExitState()
    {

    }

    public override void UpdateState(Character target)
    {
        Enemy mine = (Enemy)me;
        if (!mine.isHit)
        {
            manager.ChangeState(new EnemyWalkState(me, manager));
        }
    }
}
