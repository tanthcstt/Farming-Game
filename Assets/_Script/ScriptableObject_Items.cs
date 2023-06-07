using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Create item")]
public class ScriptableObject_Items : ScriptableObject
{
    public int itemType;
    public string itemName;
    public Sprite itemSprite;
    public int maxOfStack;

    [Header("Inside item (for bag)")] // bag of seeds, bag of something
    public GameObject insideItem;

    // for trading
    [Header("Trading")]
    public GameObject tradeItem;
    public int price = 0;
}
