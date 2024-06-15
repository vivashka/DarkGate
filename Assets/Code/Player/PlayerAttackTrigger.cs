using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTrigger : MonoBehaviour
{
    public int damage = 2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AttackPlayer attackPlayer = gameObject.GetComponent<AttackPlayer>();
        if (collision.tag == "Enemy")
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damage);
        }
    }
}
