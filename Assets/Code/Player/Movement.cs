using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float sprintSpeed = 2f;
    public float currentSpeed;

    public Animator animator;

    public Rigidbody2D rb;

    private Vector2 movement;

    float directionX;
    float directionY;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        float angle = Mathf.Atan2(moveY, moveX);
        directionX = Mathf.Cos(angle);
        directionY = Mathf.Sin(angle);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = moveSpeed * sprintSpeed;
        }
        else
        {
            currentSpeed = moveSpeed;
        }
        
        movement = new Vector2 (moveX, moveY).normalized;

        animator.SetFloat("Vertical", directionY);
        animator.SetFloat("Horizontal", directionX);
        animator.SetFloat("Speed", movement.sqrMagnitude * currentSpeed / moveSpeed);

        if (movement.sqrMagnitude > 0)
        {
            animator.SetFloat("LastH", directionX);
            animator.SetFloat("LastV", directionY);
        }
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }
}
