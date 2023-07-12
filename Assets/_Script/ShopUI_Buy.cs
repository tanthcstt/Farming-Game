using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI_Buy : ShopUI
{
    protected List<Sprite> sprites = new List<Sprite>();
    public ShopData shopData;
    protected List<ScriptableObject_Items> buyList;
    public override void Start()
    {
        buyList = shopData.GetBuyList();
        base.Start();
        UpdatePriceButton();
    }
    public override void OnSubmit()
    {     
      
        TradingManager.Instance.Buy(buyList[selectedSlot]);
    }
   
    protected override List<Sprite> GetSprite()
    {
        sprites.Clear();
        for (int i = 0; i < buyList.Count; i++)
        {
            sprites.Add(buyList[i].itemSprite);  
        }
        return sprites;
    }

    protected override int GetPrice(int index)
    {
        return buyList[index].price; 
    }
}
