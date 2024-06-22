using Assets.Code;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicYSort : MonoBehaviour
{
    private int baseSortingOrder;
    private float ySortingOffset;
    [SerializeField] private SortableSprite[] sortableSprites;
    [SerializeField] private Transform sortOffsetMarker;

    private void Start()
    {
        ySortingOffset = sortOffsetMarker.localPosition.y;
    }

    void Update()
    {
        baseSortingOrder = transform.GetSortingOrder(ySortingOffset);
        
        foreach (SortableSprite sortableSprite in sortableSprites)
        {
            sortableSprite.spriteRenderer.sortingOrder = 
                baseSortingOrder;
        }
    }

    [Serializable]
    public struct SortableSprite
    {
        public SpriteRenderer spriteRenderer;
        public int relativeOrder;
    }
}
