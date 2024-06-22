using System;
using UnityEngine;

[Serializable]
public class Entity : MonoBehaviour
{
    public int health;

    public int maxHealth;

    public int damage;

    public int speed;

    public bool isAttacked = false;
}
