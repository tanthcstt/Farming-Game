using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDestroying : PlayerAbility
{
    public override void UpdateBehaviour(PlayerAbilityManager manager) { }
    protected GameObject target;

    protected void Destroy()
    {      
  
        target.SetActive(false);
    }

    protected void Drop()
    {
        if (GetDropPrefab() == null) return;    
        GameObject dropObj = Instantiate(GetDropPrefab());
        dropObj.transform.position = target.transform.position;
    }
    protected virtual void SetTarget()
    {
        target = TargetManager.Instance.playerTarget.ForwardTarget(LayerMask.GetMask("Destroyable_Env"));
    }
    protected virtual GameObject GetDropPrefab()
    {
        if (target.GetComponent<DestroyableEnvObjData>())
        {
            return target.GetComponent<DestroyableEnvObjData>().general.dropItem;
        }
        return null;
    }
}
