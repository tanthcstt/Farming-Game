using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour
{
    private PlayerAbility currentBehaviour;
    public AbilityPlanting planting;
    public AbilityHoeing hoeing;
    public AbilityCuttingTree cuttingTree;
    public AbilityRockDaming rockDam;
    public AbilityHarvest harvest;

    
    private MoveByKey moveByKey;

    private void Start()
    {       
       
        currentBehaviour = hoeing;
    }
    private void Update()
    {
        // set behaviour by conditon
        BehaviourController();

       
        if (!Input.GetKeyDown(KeyManager.useAbility)) return;

        UseAbility();       
    }
    
    private void BehaviourController()
    {
        // test condition
        switch (InputManager.Instance.HotbarSelection)
        {
            case 0:
                SetBehaviour(hoeing);
                break;
            case 1:
                SetBehaviour(rockDam);
                break;
            case 2:
                SetBehaviour(cuttingTree);
                break;
            case 3:
                SetBehaviour(planting);
                break ;
            case 4:
                SetBehaviour(harvest);
                break;

        }
        
    }
    private void SetBehaviour(PlayerAbility behaviour)
    {
        currentBehaviour = behaviour;
    }
    public void UseAbility()
    {      
        currentBehaviour.UpdateBehaviour(this);    
    }


}
