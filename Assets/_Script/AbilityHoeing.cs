using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityHoeing : PlayerAbility
{
    /// <summary>
    /// when player hoeing mud object will instantiate on base tile (grass block)
    /// </summary>

    public GameObject cultivatedLand_Prefabs;
    public Transform baseTile;

    private static GameObject target;

  
    public override void UpdateBehaviour(PlayerAbilityManager manager)
    {
      
        PlayerHoeingController();
       
    }
    private void PlayerHoeingController()
    {
       
       
        if (target == TargetManager.Instance.GetTileMapTarget()) return;
        target = TargetManager.Instance.GetTileMapTarget();
        if (target == null) return;
        if (target.CompareTag("Grass"))
        {
           
            playerMovement.ForceStop(true);
            // hoeing
            StartCoroutine(AC_Player.WaitForAnimationEnd(AC_Player.State.Hoeing, () =>
            {
                PlayerHoeing(target);
            }));

        }     
                
    }
    private void PlayerHoeing(GameObject targeting)
    {
       
        GameObject cultivatedLand = Instantiate(cultivatedLand_Prefabs);
        Vector3 pos = new Vector3(targeting.transform.position.x, 0.5f, targeting.transform.position.z);
        cultivatedLand.transform.position = pos;
        cultivatedLand.transform.SetParent(baseTile, true);
        playerMovement.ForceStop(false);
       
    }


}
