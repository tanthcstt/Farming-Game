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
    public bool isUsableInInventory;
  
    // for trading
    [Header("Trading")]
    public GameObject prefab;
   

    public int price = 0;
}
