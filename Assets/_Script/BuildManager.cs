using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance { get; private set; }
    private BuildBehaviour buildBehaviour;
    [SerializeField] private GameObject placedObjUI;
    [SerializeField] private BuildUI buildUI;

    public enum BuildState
    {
        unActive,
        startBuild,
        ObjectCreated,
        rotate,
        endBuild // default
    }
    public BuildState currentState = BuildState.unActive;

    [Header("Cheat")]
    public bool isCostMaterial;
    private void Awake()
    {
        Instance = this;

    }
    private void Start()
    {
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
                if (isCostMaterial) // cheat here
                {
                    if (!IsEnoughMaterials())
                    {
                        SetState(BuildState.unActive);
                        break;
                    }                 
                    RemoveMaterials();
                }
                UIManager.Instance.craftingUI.SetActive(false); // fix bug
                UIManager.Instance.joystickUI.SetActive(true);// fix bug joystick ui hide
                buildBehaviour.CreateObject();             
                currentState = BuildState.ObjectCreated;
                break;

            case BuildState.ObjectCreated:

                placedObjUI.SetActive(true);

                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    buildBehaviour.SetPosByRuntime();
                }

                if (Application.platform == RuntimePlatform.WindowsEditor ||
                    Application.platform == RuntimePlatform.WindowsPlayer)
                {

                    if (Input.GetMouseButtonDown(1))
                    {
                        SetState(BuildState.endBuild);
                    }
                }
                break;

            case BuildState.rotate:
                buildBehaviour.RotateConstruction();
                SetState(BuildState.ObjectCreated);
                break;
            case BuildState.endBuild:
                if (isCostMaterial)
                {
                    buildBehaviour.RemoveConstruction();
                    if (!IsEnoughConstruction() && !IsEnoughMaterials())
                    {
                        SetState(BuildState.unActive);
                        placedObjUI.SetActive(false);
                        UIManager.Instance.joystickUI.SetActive(true);
                        break;
                    }
                }       
                SetState(BuildState.startBuild);
                break;
        }
    }

    public void SetState(BuildState state)
    {
        currentState = state;
    }

    // create new object and build 
    public void Build(GameObject constructionPrefab, BuildState state = BuildState.startBuild)
    {
        SetState(state);

        buildBehaviour.SetConstructionPrefab(constructionPrefab);
    }
   
    private bool IsEnoughMaterials()
    {
       
        List<CraftingFormula> materials = buildBehaviour.ConstrucitonPrefab.GetComponent<Construction>().construcitonData.materials;
       
        for (int i = 0; i < materials.Count; i++)
        {
            InventoryStorage storage = InventoryManager.Instance.inventoryStorage;
            if (!storage.IsEnoughItem(materials[i].item.itemType, materials[i].amount)) return false;
        }
        return true;
    }
    private bool IsEnoughConstruction()
    {
        if (buildBehaviour.BuiltConstruction.TryGetComponent<GeneralItemData>(out GeneralItemData builtConstructionData))
        {
            int type = builtConstructionData.generalData.itemType;
            if (InventoryManager.Instance.inventoryStorage.IsEnoughItem(type, 1)) return true;
        }
        return false;
    }
    // if have materials, remove materials, materials = null, remove that object
    private void RemoveMaterials()
    {       
        if (buildBehaviour.ConstrucitonPrefab.TryGetComponent<Construction>(out Construction construction))
        {
            List<CraftingFormula> materials = construction.construcitonData.materials;
            for (int i = 0; i < materials.Count; i++)
            {

                InventoryManager.Instance.RemoveItem(materials[i].item.itemType, materials[i].amount);
            }
        } 

    }
   
    public void EndBuild()
    {
        buildBehaviour.DestroyConstruction(buildBehaviour.BuiltConstruction);
        SetState(BuildState.unActive);
        placedObjUI.SetActive(false);
    }
  
}
