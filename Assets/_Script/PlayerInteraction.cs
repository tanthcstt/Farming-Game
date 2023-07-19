using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private readonly string[] interactableLayer = { "Construction", "Vehicle", "NPC", "Interactable Object" };
    public GameObject Target { get; private set; }
    [SerializeField] protected MoveByMouseClick playerMovement;
    public enum InteractionType
    {
        useAbility,
        OpenDoor,
        GetOnBoat,
        BoatDriving,
        Trading, 
        Crafting,

       
    }
    private BoatDriving boat;
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
                if (Target.TryGetComponent<BoatDriving>(out boat))
                {
                    CurrentType = InteractionType.BoatDriving;
                    boat.GetOn(transform.root.gameObject);
                }
                break;

            case InteractionType.BoatDriving:
                boat.GetOff();
                break;

            case InteractionType.Trading:
                playerMovement.ForceStop(!playerMovement.IsForceStop);
                UIManager.Instance.ToggleUI(UIManager.Instance.joystickUI);
               

                if (Target.CompareTag("Farming Shop"))
                {
                    UIManager.Instance.ToggleUI(UIManager.Instance.farmingShop);
                }
                else if (Target.CompareTag("Machine Shop"))
                {
                    UIManager.Instance.ToggleUI(UIManager.Instance.machineShop);
                }
                break;

            case InteractionType.Crafting:
                playerMovement.ForceStop(true);
                UIManager.Instance.ToggleUI(UIManager.Instance.craftingUI);                
                UIManager.Instance.ToggleUI(UIManager.Instance.joystickUI);                
                break;

            default:              
                break;
        }

    
       
    }
    // set type by runtime
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

        } else if (layerName == "Interactable Object")
        {

            if (Target.CompareTag("Crafting Table"))
            {
                CurrentType = InteractionType.Crafting;
            }
        } 

    }
}
