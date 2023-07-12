using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradingManager : MonoBehaviour
{
    public static TradingManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public void Buy(ScriptableObject_Items item)
    {
        // check if enough money
        if (CoinManager.Instance.Coin >= item.price)
        {

            GameObject newItem = Instantiate(item.prefab);
            // pickup

            InventoryManager.Instance.PickUpItem(newItem);
            // set coin
            CoinManager.Instance.UpdateCoin(CoinManager.Instance.Coin - item.price);    
        }
       
    }

    public void Sell(ScriptableObject_Items item)
    {
        if (InventoryManager.Instance.inventoryStorage.IsEnoughItem(item.itemType,1))
        {
            InventoryManager.Instance.RemoveItem(item.itemType, 1);
            CoinManager.Instance.UpdateCoin(CoinManager.Instance.Coin + item.price);
        } 
        
    }
   
   
}
