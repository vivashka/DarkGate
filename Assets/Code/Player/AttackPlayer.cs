using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public int damage;
    public Animator animator;
    public GameObject attackPoint;

    void OnFire()
    {
        animator.SetTrigger("isAttack");
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        bool isAttacking = stateInfo.IsName("Attack");

        if (isAttacking)
        {
            attackPoint.SetActive(true);
            float lastH = animator.GetFloat("LastH");
            float lastV = animator.GetFloat("LastV") / 2;

            Vector3 attackOffset = new Vector3(lastH, lastV, 0) / 5;
            attackPoint.transform.position = transform.position + attackOffset;
        }
        else
        {
            attackPoint.SetActive(false);
        }
    }
}
