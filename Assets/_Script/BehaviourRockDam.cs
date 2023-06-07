using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourRockDam : BehaviourDestroying
{
    public override void UpdateBehaviour(PlayerBehaviourManager manager)
    {
        UpdateTarget();
        if (!Input.GetKeyDown(InputManager.Instance.interactingKey)) return;

        if (target == null) return;
        if (target.activeSelf == false) return;
        if (target.CompareTag("Rock"))
        {
            Drop();
            Destroy();
        }
    }
}
