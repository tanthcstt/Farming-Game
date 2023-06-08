using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourCuttingTree : BehaviourDestroying
{
    public override void UpdateBehaviour(PlayerAbilityManager manager)
    {
        UpdateTarget();
        if (!Input.GetKeyDown(InputManager.Instance.interactingKey)) return;       
    
        if (target == null) return; 
        if (target.activeSelf == false) return; 
        if (target.CompareTag("Tree"))
        {
            Drop();
            Destroy();
        }
    }
}
