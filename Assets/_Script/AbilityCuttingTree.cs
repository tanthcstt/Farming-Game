using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCuttingTree : AbilityDestroying
{
    public override void UpdateBehaviour(PlayerAbilityManager manager)
    {
        SetTarget();
       
        if (target == null) return; 
        if (target.activeSelf == false) return; 
        if (target.CompareTag("Tree"))
        {
            Drop();
            Destroy();
        }
    }
}
