using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHarvest : AbilityDestroying
{
    public override void UpdateBehaviour(PlayerAbilityManager manager)
    {
        SetTarget();
        if (!IsValidTarget()) return;
        StartCoroutine(AC_Player.WaitForAnimationEnd(AC_Player.State.Collecting, () =>
        {
            Harvest();
        }));
    }
    protected override void SetTarget()
    {
        target = TargetManager.Instance.playerTarget.DownwardObjectTarget(LayerMask.GetMask("Plant"));
    }
       
    private void Harvest()
    {
        if (target.TryGetComponent<PlantData>(out PlantData plantData))
        {
            if (plantData == null) return;
            DropItem(plantData);
            RemoveGrownPlant();
        }

    }
    private void RemoveGrownPlant()
    {
        ObjectPooling.Instance.Despawn(target);
    }

    private void DropItem(PlantData planData)
    {
        ObjectPooling.Instance.Spawn(planData.generalData.dropItem, target.transform.position);
      
    }
    private bool IsValidTarget()
    {
        if (target && target.TryGetComponent(out PlantGrowing growing))
        {
            if (growing.Level == 2) return true;
        }
        return false;
    }
}
