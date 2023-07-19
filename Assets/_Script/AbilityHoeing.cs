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


        target = TargetManager.Instance.playerTarget.DownwardObjectTarget(LayerMask.GetMask("Base"));

        if (target == null) return;
        if (target.CompareTag("Grass"))
        {
           
            playerMovement.ForceStop(true);
            // hoeing
            StartCoroutine(AC_Player.WaitForAnimationEnd(AC_Player.State.Hoeing, () =>
            {
                Vector3 targetPos = TargetManager.Instance.playerTarget.DownwardTarget(LayerMask.GetMask("Base"));
                PlayerHoeing(Vector3Int.RoundToInt(targetPos));
            }));

        }     
                
    }
    private void PlayerHoeing(Vector3Int pos)
    {

        ObjectPooling.Instance.Spawn(cultivatedLand_Prefabs, pos);      

        playerMovement.ForceStop(false);
       
    }


}
