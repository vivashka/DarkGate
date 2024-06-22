using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : IState
{
    protected readonly Enemy enemy;
    protected readonly Animator animator;


    protected const float crossFadeDuration = 0;

    //Получение хешей Анимаций
    protected static readonly int IdleHash = Animator.StringToHash("Idle");
    protected static readonly int WalkHash = Animator.StringToHash("Movement");
    protected static readonly int AttackHash = Animator.StringToHash("Attack");



    public EnemyBaseState(Enemy enemy, Animator animator)
    {
        this.enemy = enemy;
        this.animator = animator;
    }

    public virtual void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Update()
    {
        throw new System.NotImplementedException();
    }
}
