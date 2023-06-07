using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI_Buy : ShopUI
{
    protected List<Sprite> sprites = new List<Sprite>();
    public ShopData shopData;

    public override void Start()
    {
        base.Start();
        UpdatePriceButton();
    }
    public override void OnSubmit()
    {
        // insert buy code here
        Debug.Log("bought");
        TradingManager.Instance.Buy(shopData.GetShopList()[selectedSlot]);
    }
   
    protected override List<Sprite> GetSprite()
    {
        sprites.Clear();
        for (int i = 0; i < shopData.GetShopList().Count; i++)
        {
            sprites.Add(shopData.GetShopList()[i].itemSprite);  
        }
        return sprites;
    }

    protected override int GetPrice(int index)
    {
        return shopData.GetShopList()[index].price; 
    }
}
