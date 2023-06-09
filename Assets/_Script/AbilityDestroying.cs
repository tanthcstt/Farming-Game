using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDestroying : PlayerAbility
{
    public override void UpdateBehaviour(PlayerAbilityManager manager) { }
    protected GameObject target;
    private void Update()
    {
       
    }

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
    public virtual void UpdateTarget()
    {     
        target = TargetManager.Instance.GetDestroyableObjTarget();
    }
    public virtual GameObject GetDropPrefab()
    {
        if (target.GetComponent<DestroyableEnvObjData>())
        {
            return target.GetComponent<DestroyableEnvObjData>().general.dropItem;
        }
        return null;
    }
}
