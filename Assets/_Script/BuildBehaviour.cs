using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildBehaviour : MonoBehaviour
{
    public static BuildBehaviour Instance { get; private set; }
  
    public GameObject ConstrucitonPrefab { get; private set; }
    public GameObject BuiltConstruction { get; private set; }

    public Transform ConstructionParent;
    [SerializeField] private Transform playerTransform;
    

    private void Awake()
    {
        Instance = this;
    }


    public void RotateConstruction()
    {
        Quaternion rotation = Quaternion.Euler(0, 90f, 0f);
        BuiltConstruction.transform.rotation *= rotation;
    }
    public void CreateObject()
    {        
        BuiltConstruction = ObjectPooling.Instance.Spawn(ConstrucitonPrefab, playerTransform.position + Vector3.forward * 3, true);
    }
    public void SetPosByRuntime()
    {        
        Vector3 targetPos = TargetManager.Instance.mouseTarget.MouseTargetPos(LayerMask.GetMask("Base"));
        targetPos = Vector3Int.RoundToInt(targetPos); 
        if (targetPos == Vector3.zero) return;
      
        BuiltConstruction.transform.position = targetPos;
    }
  
   
    public void DestroyConstruction(GameObject construction)
    {
        ObjectPooling.Instance.Despawn(construction);   
    }
    public void SetConstructionPrefab(GameObject constructionPrefab)
    {
        this.ConstrucitonPrefab = constructionPrefab;
       
    }

    public void RemoveConstruction()
    {
        if (BuiltConstruction.TryGetComponent<GeneralItemData>(out GeneralItemData construcitonData))
        {
            InventoryManager.Instance.RemoveItem(construcitonData.generalData.itemType, 1);
        }
        
    }

}
