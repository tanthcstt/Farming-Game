using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedsSelection : UIHotbarItemSelection
{
    public override ScriptableObject_Items GetSelectedItem()
    {
        
        return items[currentSelectedIndex];
    }
}
