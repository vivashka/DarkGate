using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public SmartMove enemyMove;
    public int attackrange;
    public GameObject attackBox;
    public Animator animator;
    public int damage = 2;

    public float attackRate = 3;
    public float attackTimer = 0;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        attackTimer -= Time.deltaTime;

        if (enemyMove.distanceToPlayer < attackrange)
        {
            if (attackTimer <= 0)
            {
                Attack();
            }
            else
            {
                attackTimer = attackRate;
            }
            
        }
        else
        {
            attackBox.SetActive(false);
            rb.velocity = Vector2.zero;
            enemyMove.moveSpeed = 3;
        }
    }

    void Attack()
    {
        enemyMove.moveSpeed = 0;
        attackBox.SetActive(true);
        attackBox.transform.position = transform.position +
            new Vector3(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"), 0);

        animator.SetTrigger("IsAttack");
        rb.AddForce(new Vector2(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical")) * 20);
    }
}
