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
            StartCoroutine(AC_Player.WaitForAnimationEnd(AC_Player.State.TreeCutting, () =>
            {
                playerMovement.ForceStop(true);
                Destroy();
                Drop();
                playerMovement.ForceStop(false);
            }));

        }
    }
}
