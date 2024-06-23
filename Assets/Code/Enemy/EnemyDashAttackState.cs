using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDashAttackState : EnemyBaseState
{

    Rigidbody2D rb;
    float attackRate;
    float attackTimer;

    Vector2 originalposition;

    public EnemyDashAttackState(Enemy enemy, Animator animator, Transform target, float timer) : base(enemy, animator)
    {
        rb = enemy.GetComponent<Rigidbody2D>();
        attackRate = timer;
    }

    public void Attack()
    {
        enemy.isAttacking = true;
        float x = animator.GetFloat("LastH");
        float y = animator.GetFloat("LastV");
        rb.MovePosition((Vector2)enemy.transform.position + (new Vector2(x, y).normalized) * 20 * Time.fixedDeltaTime);
        if (Math.Abs((originalposition - (Vector2)enemy.transform.position).magnitude) > 4)
        {
            attackTimer = attackRate;
            enemy.isAttacking = false;
        }
    }

    public override void OnEnter()
    {
        animator.CrossFade(AttackHash, crossFadeDuration);
        originalposition = new Vector2(enemy.transform.position.x, enemy.transform.position.y);
        enemy.attackBox.SetActive(true);
    }

    public override void Update()
    {

    }

    public override void FixedUpdate()
    {
        attackTimer -= Time.fixedDeltaTime;
        //Debug.Log(attackTimer);
        if (attackTimer < 0)
        {
            Attack();
        }
        
    }

    public override void OnExit()
    {
        
    }
}
