using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildBehaviour : MonoBehaviour
{
    public static BuildBehaviour Instance { get; private set; }
    private readonly float heightOffset = 0.5f;
    public GameObject ConstrucitonPrefab { get; private set; }
    public GameObject BuiltConstruction { get; private set; }

    public Transform ConstructionParent;

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
        BuiltConstruction = Instantiate(ConstrucitonPrefab,ConstructionParent);
    }
    public void SetPosByRuntime()
    {
        Vector3 pos = TargetManager.Instance.mouseTarget.MouseTargetObj(LayerMask.GetMask("Base")).transform.position;
        pos.y += heightOffset;
        BuiltConstruction.transform.position = pos;

    }
    public void DestroyConstruction(GameObject construction)
    {
        Destroy(construction);
    }
    public void SetConstructionPrefab(GameObject constructionPrefab)
    {
        this.ConstrucitonPrefab = constructionPrefab;
       
    }

}
