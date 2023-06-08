using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void Update()
    {
        if (!Input.GetMouseButtonDown(1)) return;
        GameObject target = TargetManager.Instance.mouseTarget.MouseTargetObj(LayerMask.GetMask("Construction"));
        if (target && target.TryGetComponent(out FenceDoorOpening doorOpening))
        {
            doorOpening.ToggleDoor();
        }
    }
}
