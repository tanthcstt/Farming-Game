using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryStorage : MonoBehaviour
{

    protected List<GeneralItemData> inventoryList = new List<GeneralItemData>();
    public List<GeneralItemData> InventoryList { get { return inventoryList; } }
    public readonly int maxInventorySlot = 9;
   
    private void Awake()
    {
        ListInit();
    }
    private void ListInit()
    {
        for (int i = 0; i < maxInventorySlot; i++)
        {
            inventoryList.Add(null);
        }
    }
    // only add data use pick up  in inventory manager for both data and ui
    public void AddToStorage(GeneralItemData itemData)
    {

        if (IsContainItem(itemData) && GetNotFullSlot(itemData) == -1) // case 1
        {
            AddToEmptySlot(itemData, GetEmptySlotIndex());
        }
        else if (IsContainItem(itemData) && GetNotFullSlot(itemData) != -1) // case 2
        {
            AddToAvailableSlot(GetNotFullSlot(itemData));

        }
        else // case 3
        {
            AddToEmptySlot(itemData, GetEmptySlotIndex());
        }

        itemData.gameObject.SetActive(false);

    }
    // only remove data use remove in inventory manager for both data and ui
    public void RemoveFromStorage(int itemType, int amount)
    {
        for (int i = 0; i < inventoryList.Count; i++)
        {
            if (inventoryList[i] == null) continue;
            if (inventoryList[i].generalData.itemType != itemType) continue;
            if (inventoryList[i].count > amount)
            {
                inventoryList[i].count -= amount;
                break;
            }
            else if (inventoryList[i].count < amount)
            {
                amount -= inventoryList[i].count;
                inventoryList[i] = null;
            }
            else
            {
                inventoryList[i] = null;
                break;
            }
        }
    }
    int GetEmptySlotIndex()
    {
        for (int i = 0; i < maxInventorySlot; i++)
        {
            if (inventoryList[i] == null) return i;
        }
        return -1;
    }
    private void AddToEmptySlot(GeneralItemData itemData, int slotIndex)
    {
        if (slotIndex == -1) return;
        itemData.count = 1;
        inventoryList[slotIndex] = itemData;
    }
    private int GetNotFullSlot(GeneralItemData itemData)
    {
        int i;
        for (i = 0; i < maxInventorySlot; i++)
        {
            if (inventoryList[i] == null) continue;
            if (inventoryList[i].generalData.itemType != itemData.generalData.itemType) continue;
            if (inventoryList[i].count >= itemData.generalData.maxOfStack) continue;
            return i;
        }
        return -1;
    }
    // increase amount
    private void AddToAvailableSlot(int index)
    {
        inventoryList[index].count++;
    }
    private bool IsContainItem(GeneralItemData item)
    {
        for (int i = 0; i < maxInventorySlot; i++)
        {
            if (inventoryList[i] == null) continue;
            if (inventoryList[i].generalData.itemType == item.generalData.itemType) return true;
        }
        return false;
    }
    public bool IsEnoughItem(int itemType, int amount)
    {
        int count = 0;
        for (int i = 0; i < inventoryList.Count; i++)
        {
            if (inventoryList[i] == null) continue;
            if (inventoryList[i].generalData.itemType != itemType) continue;
            count += inventoryList[i].count;
            if (count >= amount) return true;
        }
        return false;
    }

}
