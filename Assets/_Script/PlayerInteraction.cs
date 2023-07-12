using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private readonly string[] interactableLayer = { "Construction", "Vehicle", "NPC" };
    public GameObject Target { get; private set; }
    
    public enum InteractionType
    {
        useAbility,
        OpenDoor,
        GetOnBoat,
        Trading
    }
    public InteractionType CurrentType { get; private set; }
    private void Update()
    {      

        SetTarget();
        SetType();
    }
    
    private void SetTarget()
    {
        Target = TargetManager.Instance.GetInteractiveTarget(LayerMask.GetMask(interactableLayer));        
    }
    public void Interact()
    {
        switch (CurrentType)
        {
            case InteractionType.OpenDoor:
                if (Target.TryGetComponent(out FenceDoorOpening doorOpening)) doorOpening.ToggleDoor();
                break;
            case InteractionType.GetOnBoat:
                if (Target.TryGetComponent(out BoatDriving boat))
                {
                    boat.GetOn(transform.root.gameObject);
                }
                break;
            case InteractionType.Trading:
                UIManager.Instance.ToggleUI(UIManager.Instance.tradingUI);   
                break;
            default:
                break;
        }

    
       
    }
    private void SetType()
    {
        if (Target == null)
        {
            CurrentType = InteractionType.useAbility;
            return; 
        }

        var layerName = LayerMask.LayerToName(Target.layer);
        if (layerName == "Construction")
        {
            CurrentType = InteractionType.OpenDoor;
        } else if (layerName == "Vehicle")
        {
            CurrentType = InteractionType.GetOnBoat;
        } else if (layerName == "NPC")
        {
            CurrentType = InteractionType.Trading;
            
        }

    }
}
