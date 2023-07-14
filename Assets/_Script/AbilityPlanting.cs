using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AbilityPlanting : PlayerAbility
{

    public Transform plantingGrid; 
    private static GameObject targeting;
    public SeedsSelection seedSelection;
    private GameObject seedPrefab;
    public override void UpdateBehaviour(PlayerAbilityManager manager)
    {
        Plant();  

    }
    /// <summary>
    /// 1. get target
    /// 2. check if player has this seed in inventory
    /// 3. check for valid target
    /// 4.place object
    /// 5. remove seed from inventory
    /// </summary>
    private void Plant()
    {

        targeting = TargetManager.Instance.playerTarget.DownwardObjectTarget(LayerMask.GetMask("Base"));
        if (targeting == null) return;
        // is valid target
        if (IsPlanted()) return;
        if (!targeting.CompareTag("Cultivated Land")) return;

        // is player has seed bag
        int seedBagType = seedSelection.GetSelectedItem().itemType;
        if (!InventoryManager.Instance.inventoryStorage.IsEnoughItem(seedBagType, 1)) return;
        seedPrefab = seedSelection.GetSelectedItem().prefab.GetComponent<GeneralItemData>().generalData.prefab;
        
        // place plant       
        PlaceObj(targeting.transform.position);

        //remove seeds
        InventoryManager.Instance.RemoveItem(seedBagType, 1);
    }

  
    private void PlaceObj(Vector3 pos)
    {
        ObjectPooling.Instance.Spawn(seedPrefab.gameObject,pos);        
    }
  
    private bool IsPlanted()
    {
        return (TargetManager.Instance.playerTarget.TargetToPoint(targeting.transform.position, LayerMask.GetMask("Plant")) != null);
    }
    
}
