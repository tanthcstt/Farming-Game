using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI_Sell : ShopUI
{
    [SerializeField] private ShopData shopData;
    protected List<Sprite> sprites = new List<Sprite>();
    protected List<ScriptableObject_Items> sellList;
    public override void Start()
    {
        sellList = shopData.GetSellList();
        base.Start();
        UpdatePriceButton();
    }
    public override void OnSubmit()
    {
        TradingManager.Instance.Sell(sellList[selectedSlot]);
    }

    protected override List<Sprite> GetSprite()
    {
        sprites.Clear();
       
        for (int i = 0; i < sellList.Count; i++)
        {
            sprites.Add(sellList[i].itemSprite);
        }
        return sprites;
    }
    protected override int GetPrice(int index)
    {
        return sellList[index].price;
    }
}
