using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance { get; private set; }
    private BuildBehaviour buildBehaviour;

   
    public enum BuildState
    {
        unActive,
        startBuild,
        ObjectCreated,
        rotate,
        endBuild // default
    }
    private BuildState currentState = BuildState.unActive;
    [Header("Cheat")]
    public bool isCostMaterial;
    private void Awake()
    {
        Instance = this;
        buildBehaviour = BuildBehaviour.Instance;
    }
    private void Update()
    {
        
        BuildStateTransition();
    }
    private void BuildStateTransition()
    {
        switch (currentState)
        {
            case BuildState.unActive:
                break;
            case BuildState.startBuild:
                if (isCostMaterial) // use cheat
                {
                    if (!IsEnoughMaterials())
                    {
                        SetState(BuildState.unActive);
                        break;
                    }
                }
               
                buildBehaviour.CreateObject();
                RemoveMaterials();  
                currentState = BuildState.ObjectCreated;
                break;
            case BuildState.ObjectCreated:
                buildBehaviour.SetPosByRuntime();
                if (Input.GetMouseButtonDown(1))
                {
                    SetState(BuildState.endBuild);
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SetState(BuildState.rotate);
                }
                if (Input.GetMouseButtonDown(0))
                {
                    buildBehaviour.DestroyConstruction(buildBehaviour.BuiltConstruction);   
                    SetState(BuildState.unActive);
                }
                break;
            case BuildState.rotate:
                buildBehaviour.RotateConstruction();
                SetState(BuildState.ObjectCreated);
                break;
            case BuildState.endBuild:               
                SetState(BuildState.startBuild);
                break;
        }
    }

    private void SetState(BuildState state)
    {
        currentState = state;
    }
    public void Build(GameObject constructionPrefab, BuildState state)
    {
        SetState(state);
       
        buildBehaviour.SetConstructionPrefab(constructionPrefab);
    }
   
    private bool IsEnoughMaterials()
    {
        List<CraftingFormula> materials = buildBehaviour.ConstrucitonPrefab.GetComponent<Construction>().construcitonData.materials;
        Debug.Log(materials.Count);
        for (int i = 0; i < materials.Count; i++)
        {
            InventoryStorage storage = InventoryManager.Instance.inventoryStorage;
            if (!storage.IsEnoughItem(materials[i].item.itemType, materials[i].amount)) return false;
        }
        return true;
    }
    private void RemoveMaterials()
    {
        List<CraftingFormula> materials = buildBehaviour.ConstrucitonPrefab.GetComponent<Construction>().construcitonData.materials;
        Debug.Log(materials.Count);
        for (int i = 0; i < materials.Count; i++)
        {
           
            InventoryManager.Instance.RemoveItem(materials[i].item.itemType, materials[i].amount);
        }
      

    }


}
