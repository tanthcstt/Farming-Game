using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CraftingUI : ShopUI
{
    public CraftingData CraftingData;
    public GameObject CraftBtn;
    public GameObject UIItemPrefab;

    
    private Transform materialContent;
    protected List<Sprite> craftingSprites = new List<Sprite>();
    private Image craftingObjImg;
   
    
    public override void Start()
    {
        base.Start();
        ChangeDiscriptionUI();        
        
    }

   
    public override void LoadComponent()
    {
        base.LoadComponent();

        Transform discriptionContent = transform.parent.Find("Discription/Content");
        craftingObjImg = discriptionContent.Find("Crafting").GetComponent<Image>();
        materialContent = discriptionContent.Find("MaterialContent");      
    }

    protected void ChangeDiscriptionUI()
    {
        ClearMaterialsContent();
        craftingObjImg.sprite = CraftingData.SOConstructions[selectedSlot].sprite;

        List<CraftingFormula> materials = CraftingData.SOConstructions[selectedSlot].materials;
        for (int i = 0; i < materials.Count; i++)
        {
            GameObject matUI = Instantiate(UIItemPrefab, materialContent);

            Image matImg = matUI.transform.Find("Sprite").GetComponent<Image>();
            matImg.sprite = materials[i].item.itemSprite;

            TextMeshProUGUI itemName = matUI.transform.Find("Name").GetComponent<TextMeshProUGUI>();
            itemName.text = materials[i].item.itemName;

            TextMeshProUGUI count = matUI.transform.Find("Count").GetComponent<TextMeshProUGUI>();
            count.text = materials[i].amount.ToString();
        }
    }

    public override void SelectItem(int selectedSlot)
    {
        base.SelectItem(selectedSlot);
        ChangeDiscriptionUI();
    }
    public override void OnSubmit()
    {    
        BuildManager.Instance.Build(CraftingData.SOConstructions[selectedSlot].prefab, BuildManager.BuildState.startBuild);       
        UIManager.Instance.ToggleUI(transform.parent.gameObject);

    }

    protected override int GetPrice(int index)
    {
        throw new System.NotImplementedException();
    }

    protected override List<Sprite> GetSprite()
    {
        craftingSprites.Clear();
        for (int i = 0; i < CraftingData.SOConstructions.Count; i++)
        {
            craftingSprites.Add(CraftingData.SOConstructions[i].sprite);
        }
        return craftingSprites;
    }
    // crafting button do not have price to update
    public override void UpdatePriceButton() { }
    protected void ClearMaterialsContent()
    {
        foreach (Transform trans in materialContent)
        {
            Destroy(trans.gameObject);
        }
    }
}
