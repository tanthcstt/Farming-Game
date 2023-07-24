using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public GameObject UIPrefabs_Item;  
    [Header("UIPrefabs_Item Component")]
    private Image itemSprite;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI itemCount;


 

    private void Start()
    {       
        AddItemUIListener();     
      
    }
    private void OnEnable()
    {
        UpdateInventoryUI(InventoryManager.Instance.inventoryStorage.InventoryList);
        
    }


    private void SetComponent(GameObject obj)
    {        
        itemSprite = obj.transform.Find("Sprite").GetComponent<Image>();        
        itemName = obj.transform.Find("Name").GetComponent<TextMeshProUGUI>();    
        itemCount = obj.transform.Find("Count").GetComponent<TextMeshProUGUI>();
     
    }
   
   
    private void LoadUIData(GeneralItemData data)
    {
        itemSprite.sprite = data.generalData.itemSprite;
        itemCount.text = data.count.ToString();
        itemName.text = data.generalData.itemName;
    }
   
    public void UpdateInventoryUI(List<GeneralItemData> inventoryList)
    {
        ResetInventoryUI();

        int inventCount = inventoryList.Count(item => item != null);
        int slotIndex = 0;

        for (int i = 0; i < inventoryList.Count; i++)
        {
            if (inventoryList[i] == null) continue;

            Transform slot = transform.GetChild(slotIndex);
            slot.GetChild(0).gameObject.SetActive(true);
            SetComponent(slot.GetChild(0).gameObject);
            LoadUIData(inventoryList[i]);
            slotIndex++;
        }

     

    }

    private void ResetInventoryUI()
    {
        foreach (Transform slot in transform)
        {
            slot.GetChild(0).gameObject.SetActive(false);
        }
    }
  
   
    private void AddItemUIListener() 
    {
        foreach(Transform child in transform)
        {
            if (child.TryGetComponent<Button>(out Button btn))
            {
                btn.onClick.AddListener(() =>
                {
                    InventoryManager.Instance.UseItem(child.GetSiblingIndex());
                   
                });
            }
        }
    }
}
