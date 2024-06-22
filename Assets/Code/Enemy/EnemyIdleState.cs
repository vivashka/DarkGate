using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{

    public EnemyIdleState(Enemy enemy, Animator animator) : base(enemy, animator)
    {
    }

    public void Patrool()
    {
        animator.CrossFade(IdleHash, crossFadeDuration);
    }
    public override void OnEnter()
    {
        animator.CrossFade(IdleHash, crossFadeDuration);
    }

    public override void Update()
    {

    }

    public override void FixedUpdate()
    {
        Patrool();
    }

    public override void OnExit()
    {

    }
}
