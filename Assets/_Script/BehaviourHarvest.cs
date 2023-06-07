using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourHarvest : BehaviourDestroying
{
    public override void UpdateBehaviour(PlayerBehaviourManager manager)
    {
        UpdateTarget();
        Harvest();
    }
    public override void UpdateTarget()
    {
        target = TargetManager.Instance.playerTarget.DownwardTarget(LayerMask.GetMask("Plant"));
       
        
    }
    private void Harvest()
    {
        if (!Input.GetKey(InputManager.Instance.interactingKey)) return;

        if (target && target.GetComponent<PlantGrowing>())
        {
            int growLevel = target.GetComponent<PlantGrowing>().Level;
            if (growLevel < 2) return;            
            if (target.TryGetComponent<PlantData>(out PlantData plantData))
            {
                if (plantData == null) return;
                DropItem(plantData);
                RemoveGrownPlant();
            }
           
        }
    }
    private void RemoveGrownPlant()
    {
        target.SetActive(false);
    }

    private void DropItem(PlantData planData)
    {
        GameObject drop = Instantiate(planData.generalData.dropItem);
        drop.transform.position = target.transform.position;
    }

}
