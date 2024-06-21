using System;
using System.Collections;
using UnityEngine;

public class DashAttack : MonoBehaviour
{
    public int attackRange;
    public GameObject attackBox;
    public Animator animator;
    public int damage = 2;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Attack(Transform target)
    {
        Vector2 attackDirection = ((Vector2)target.position - (Vector2)transform.position).normalized;
        float x = animator.GetFloat("Horizontal");
        float y = animator.GetFloat("Vertical");
        Vector2 lastPosition = (Vector2)transform.position;
        rb.MovePosition((Vector2)transform.position + new Vector2(x, y));

        float vectorLength = (float)Math.Sqrt(Math.Pow(transform.position.x - lastPosition.x, 2) +
            Math.Pow(transform.position.y - lastPosition.y, 2));
    }

    public void VectorCalc(Vector2 lastPosition)
    {
        float vectorLength = (float)Math.Sqrt(Math.Pow(transform.position.x - lastPosition.x, 2) +
            Math.Pow(transform.position.y - lastPosition.y, 2));

        print(vectorLength);
    }
}
