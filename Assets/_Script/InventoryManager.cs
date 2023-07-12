using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    public UIInventory inventoryUI;
  
    public InventoryStorage inventoryStorage;
    private void Awake()
    {
        Instance = this;        
       
    }
    public void PickUpItem(GameObject item)
    {
        GeneralItemData itemData = item.GetComponent<GeneralItemData>();
        if (item == null)
        {
            Debug.LogWarning("null item data");
            return;
        }
        inventoryStorage.AddToStorage(itemData);
        inventoryUI.UpdateInventoryUI(inventoryStorage.InventoryList);
        item.SetActive(false);
    }

    public void RemoveItem(int itemType, int amount)
    {
        inventoryStorage.RemoveFromStorage(itemType, amount);
        inventoryUI.UpdateInventoryUI(inventoryStorage.InventoryList);
    }

    public void UseItem(int index)
    {
        var item = inventoryStorage.InventoryList[index];
        if (item == null) return;
        if (!item.generalData.isUsableInInventory) return;

      
        if (item.generalData.isUsableInInventory)
        {
            // build
            item.gameObject.SetActive(true);
         
            // place to ground use build system          
            BuildManager.Instance.Build(item.gameObject,BuildManager.BuildState.startBuild);
        }
    }

}
