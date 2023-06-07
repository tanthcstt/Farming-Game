using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BehaviourHoeing : PlayerBehaviour
{
    /// <summary>
    /// when player hoeing mud object will instantiate on base tile (grass block)
    /// </summary>

    public GameObject cultivatedLand_Prefabs;
    public Transform baseTile;

    private static GameObject target;

  
    public override void UpdateBehaviour(PlayerBehaviourManager manager)
    {
      
        PlayerHoeingController();
       
    }
    private void PlayerHoeingController()
    {
        // condition
        if (!Input.GetKey(InputManager.Instance.interactingKey)) return;
        if (target == TargetManager.Instance.GetTileMapTarget()) return;
        target = TargetManager.Instance.GetTileMapTarget();
        if (target == null) return;
        if (target.CompareTag("Grass"))
        {            
            // hoeing
            StartCoroutine(PlayerHoeing(target));
        }     
                
    }
    private IEnumerator PlayerHoeing(GameObject targeting)
    {
        while(!AnimationManager.Instance.IsTransitTo(playerAnimator,"Collecting", "Idle"))
        {
            yield return null;  
        }

        GameObject cultivatedLand = Instantiate(cultivatedLand_Prefabs);
        Vector3 pos = new Vector3(targeting.transform.position.x, 0.5f, targeting.transform.position.z);
        cultivatedLand.transform.position = pos;
        cultivatedLand.transform.SetParent(baseTile, true);
    }


}
