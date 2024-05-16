using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа

    public Rigidbody2D rb;

    private Vector2 movement;

    void Update()
    {
        // Получение ввода от пользователя по осям X и Y
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Создание вектора движения
        
    }

    private void FixedUpdate()
    {

        // Применение движения к transform
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
