using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private readonly string[] interactableLayer = { "Construction", "Vehicle" };
    private GameObject target;
    private void Update()
    {
        if (!Input.GetKeyDown(KeyManager.interact)) return;

        target = TargetManager.Instance.GetInteractiveTarget(LayerMask.GetMask(interactableLayer));
        if (target == null) return;
        string layerName = LayerMask.LayerToName(target.layer);   
        
        switch(layerName)
        {
            case "Construction":
                if (target.TryGetComponent(out FenceDoorOpening doorOpening)) doorOpening.ToggleDoor();
                break;
            case "Vehicle":
                if (target.TryGetComponent(out BoatDriving boat))
                {                   
                    boat.GetOn(transform.root.gameObject);                   
                }
                break ; 
        }
       
    }
  
   
}
