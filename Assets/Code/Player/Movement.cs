using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 2f; // Скорость движения персонажа

    public Animator animator;

    public Rigidbody2D rb;

    private Vector2 movement;

    void Update()
    {
        // Получение ввода от пользователя по осям X и Y
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);



        if (movement.sqrMagnitude > 0)
        {
            animator.SetFloat("LastH", movement.x);
            animator.SetFloat("LastV", movement.y);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= 1.5f;
        }
        
    }

    private void FixedUpdate()
    {
        // Применение движения к transform
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
