using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : MonoBehaviour
{
    public Rigidbody2D creature;

    public void Freeze()
    {
        creature.freezeRotation = true;
        creature.constraints = RigidbodyConstraints2D.FreezePosition;
    }
}
