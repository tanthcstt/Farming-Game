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
    private readonly int inventorySlot = 16;

    private void Start()
    {
        AddItemUIListener();
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
    /// <summary>
    /// if data != null && UI empty => instantiate new ui,
    ///    data!=null && ui instantiated ==> update ui ;
    /// </summary>
    /// <param name="inventoryList"></param>
    public void UpdateInventoryUI(List<GeneralItemData> inventoryList)
    {
        int listSize = inventoryList.Count(item => item != null); //size of  unNull list
        for (int i = 0; i < inventoryList.Count; i++)
        {

            if (inventoryList[i] == null) continue;
            if (inventoryList[i] != null && transform.GetChild(i).childCount != 0)
            {
                Transform slotTransform = transform.GetChild(i);
                // reActivate if child activeSelf is set to false
                slotTransform.GetChild(0).gameObject.SetActive(true);
                SetComponent(slotTransform.GetChild(0).gameObject);
                LoadUIData(inventoryList[i]);
            }
            if (inventoryList[i] != null && transform.GetChild(i).childCount == 0)
            {
                GameObject newItemUI = Instantiate(UIPrefabs_Item, transform.GetChild(i));
                SetComponent(newItemUI);
                LoadUIData(inventoryList[i]);
            }

        }
        for (int i = listSize; i < inventorySlot; i++)
        {
            Transform slot = transform.GetChild(i);
            if (slot.childCount > 0)
            {
                slot.GetChild(0).gameObject.SetActive(false); 
            }
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
