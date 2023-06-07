using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourManager : MonoBehaviour
{
    private PlayerBehaviour currentBehaviour;
    public BehaviourPlanting planting;
    public BehaviourHoeing hoeing;
    public BehaviourCuttingTree cuttingTree;
    public BehaviourRockDam rockDam;
    public BehaviourHarvest harvest;

   

    private void Start()
    {       
        currentBehaviour = hoeing;
    }
    private void Update()
    {
        // set behaviour by conditon
        BehaviourController();
        // behaviour loop
        currentBehaviour.UpdateBehaviour(this);
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
    private void SetBehaviour(PlayerBehaviour behaviour)
    {
        currentBehaviour = behaviour;
    }


}
