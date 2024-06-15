using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AttackPlayer attackPlayer = gameObject.GetComponent<AttackPlayer>();
        if (collision.tag == "Enemy")
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(2);
        }
    }
}