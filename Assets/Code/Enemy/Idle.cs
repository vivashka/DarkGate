using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MonoBehaviour
{
    public Rigidbody2D creature;

    public void Patrool()
    {
        creature.freezeRotation = true;
        creature.constraints = RigidbodyConstraints2D.FreezePosition;
    }
}
