using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ShopData : MonoBehaviour
{

    [SerializeField] protected List<ScriptableObject_Items> buyList;
    [SerializeField] protected List<ScriptableObject_Items> sellList;
    public  List<ScriptableObject_Items> GetBuyList()
    {
        return buyList;
    }
    public  List<ScriptableObject_Items> GetSellList()
    {
        return sellList;
    }
   
}
