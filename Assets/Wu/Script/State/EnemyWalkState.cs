using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyWalkState : BaseState
{
    public EnemyWalkState(Character c, StateManager m) : base(c, m) { }

    public override void EnterState()
    {
        Enemy mine = (Enemy)me;
        mine.GetAnimator().SetBool("isWalk", true);
    }

    public override void ExitState()
    {
    }

    public override void UpdateState(Character target)
    {
        Enemy mine = (Enemy)me;
        // UŒ‚‚³‚ê‚½

        //ˆÚ“®
        if (mine.IsAlive())
        {
            mine.Move();
        }
    }
}
