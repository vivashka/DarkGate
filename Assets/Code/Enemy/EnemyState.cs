using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public SmartMove smartMove;
    public EnemyAttack enemyAttack;
    public EnemyIdle enemyIdle;

    public State state;

    private void Update()
    {

        if (state == State.Follow)
        {
            smartMove.FollowToTarget();
        }
        else if (state == State.Attack)
        {
            enemyAttack.Attack();
        }
        else if (state == State.Idle) 
        {
            enemyIdle.Freeze();
        }
    }

    public enum State
    {
        Attack,
        Follow,
        Idle
    }
}
