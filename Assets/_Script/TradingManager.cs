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
            // pickup
            InventoryManager.Instance.PickUpItem(item.tradeItem);
            // set coin
            CoinManager.Instance.UpdateCoin(CoinManager.Instance.Coin - item.price);    
        }
       
    }

    public void Sell(ScriptableObject_Items item)
    {
        InventoryManager.Instance.RemoveItem(item.itemType, 1);
    }
   
   
}
