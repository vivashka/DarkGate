using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public int damage;
    public Animator animator;
    public GameObject attackPoint;
    float scaleFactor;

    private void Start()
    {
        scaleFactor = transform.localScale.x + transform.localScale.y;
    }

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
            AttackOffset();
        }
        else
        {
            attackPoint.SetActive(false);
        }
    }

    private void AttackOffset()
    {
        float lastH = animator.GetFloat("LastH");
        float lastV = animator.GetFloat("LastV");

        if (Math.Abs(lastH) == Math.Abs(lastV))
        {
            lastH = 0;
        }

        Vector3 attackOffset = new Vector3(lastH * 1.3f, lastV, 0);
        attackPoint.transform.position = transform.position + attackOffset;
        AttackBox(Math.Abs(lastH) * scaleFactor, Math.Abs(lastV) * scaleFactor);
    }

    private void AttackBox(float offsetX, float offsetY)
    {
        BoxCollider2D hitbox = attackPoint.GetComponent<BoxCollider2D>();
        float borderX = Math.Abs(attackPoint.transform.localPosition.x) * 2;
        float borderY = Math.Abs(attackPoint.transform.localPosition.y) * 2;

        hitbox.size = new Vector2(borderX + offsetY, borderY + offsetX);
    }
}
