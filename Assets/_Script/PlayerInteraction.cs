using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void Update()
    {
        OpenDoor();
        BoatDriving();
    }
    private void BoatDriving()
    {
        if (!Input.GetMouseButtonDown(1)) return;    
        GameObject target = TargetManager.Instance.mouseTarget.MouseTargetObj(LayerMask.GetMask("Vehicle"));
        if (target && target.TryGetComponent(out BoatDriving boatDriving))
        {
            boatDriving.GetOn(transform.root.gameObject);
        }
    }
    private void OpenDoor()
    {
        if (!Input.GetMouseButtonDown(1)) return;
        GameObject target = TargetManager.Instance.mouseTarget.MouseTargetObj(LayerMask.GetMask("Construction"));
        if (target && target.TryGetComponent(out FenceDoorOpening doorOpening))
        {
            doorOpening.ToggleDoor();
        }
    }
}
