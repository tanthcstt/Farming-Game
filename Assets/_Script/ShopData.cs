using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShopData : MonoBehaviour
{
    public abstract List<ScriptableObject_Items> GetShopList();
   
}
