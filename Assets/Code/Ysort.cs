using Assets.Code;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ysort : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = transform.GetSortingOrder();
    }
}
