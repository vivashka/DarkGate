using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public SmartMove smartMove;
    public DashAttack enemyAttack;
    public Idle enemyIdle;
    public Damaged damaged;

    public State state;

    public float distanceToTarget;

    public Transform target;

    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (state == State.Damaged)
        {
            damaged.Disarrange();
        }
        else if (state == State.Follow)
        {
            smartMove.FollowToTarget();
        }
        else if (state == State.Attack)
        {
            enemyAttack.Attack(target);
        }
        else if (state == State.Idle)
        {
            enemyIdle.Patrool();
        }
    }
    public enum State
    {
        Attack,
        Follow,
        Idle,
        Damaged
    }
}
