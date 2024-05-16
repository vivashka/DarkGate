using Assets.Code;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicYSort : MonoBehaviour
{
    private int baseSortingOrder;
    private float ySortingOffset;
    [SerializeField] private SortableSprite[] sortableSprite;
    [SerializeField] private Transform sortOffsetMarker;

    private void Start()
    {
        ySortingOffset = sortOffsetMarker.position.y;
    }

    void Update()
    {
        baseSortingOrder = transform.GetSortingOrder(ySortingOffset);
        
        foreach (var sortableSprite in sortableSprite)
        {
            sortableSprite.spriteRenderer.sortingOrder = 
                baseSortingOrder + sortableSprite.relativeOrder;
        }
    }

    [Serializable]
    public struct SortableSprite
    {
        public SpriteRenderer spriteRenderer;
        public int relativeOrder;
    }
}
