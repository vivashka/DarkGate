using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public SmartMove enemyMove;
    public int attackrange;
    public GameObject attackBox;
    public Animator animator;
    public int damage = 2;

    void Start()
    {

    }

    void Update()
    {
        if (enemyMove.distanceToPlayer < attackrange)
        {
            attackBox.SetActive(true);
            attackBox.transform.position = transform.position +
                new Vector3(animator.GetFloat("LastH"), animator.GetFloat("LastV"), 0);
            animator.SetTrigger("IsAttack");
        }
        else
        {
            attackBox.SetActive(false);
        }
        
    }
}
