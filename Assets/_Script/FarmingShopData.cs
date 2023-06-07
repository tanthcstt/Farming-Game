using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingShopData : ShopData
{
    public List<ScriptableObject_Items> farmingList;
    public override List<ScriptableObject_Items> GetShopList()
    {
        return farmingList;
    }
}
