using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRockDaming : AbilityDestroying
{
    public override void UpdateBehaviour(PlayerAbilityManager manager)
    {
        SetTarget();
       

        if (target == null) return;
        if (target.activeSelf == false) return;
        if (target.CompareTag("Rock"))
        {           

            StartCoroutine(AC_Player.WaitForAnimationEnd(AC_Player.State.Mining, () =>
            {               
                Destroy();
                Drop();               
               
            }));

        }
    }
    
}
