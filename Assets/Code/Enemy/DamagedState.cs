using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagedState : EnemyBaseState
{
    public delegate bool HealthHandler();

    public HealthHandler healthHandler;

    public DamagedState(Enemy enemy, Animator animator) : base(enemy, animator)
    {

    }

    public void TakeDamage(int damage)
    {
        enemy.health -= damage;
        enemy.isAttacked = (bool)(healthHandler?.Invoke());
        if (enemy.health <= 0)
        {
           
        }
    }

    public void Disarrange()
    {

    }

    public virtual void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnEnter()
    {
        TakeDamage(enemy.damage);
    }

    public virtual void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Update()
    {
        throw new System.NotImplementedException();
    }
}
