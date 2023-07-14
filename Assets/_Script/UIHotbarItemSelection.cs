using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHotbarItemSelection : MonoBehaviour
{
    public Transform UIContent;
    public ShopData shopData;
    protected List<ScriptableObject_Items> items = new List<ScriptableObject_Items>();
    protected int currentSelectedIndex = 0;
    protected bool isActive = false;
    private void OnEnable()
    {
        if (!isActive)
        {
            ActiveSelectionUI();
            isActive = true;
        }
       

    }
    
    private void OnDisable()
    {
        isActive = false;
        RemoveListener();   
    }
    public void ActiveSelectionUI()
    {
        ListInit();
        LoadImageToSlot();
        AddListener();  
    }
    private void LoadImageToSlot()
    {
        for (int i = 0; i < UIContent.childCount; i++)
        {
            Image image = UIContent.GetChild(i).GetChild(0).GetComponent<Image>();
            if (i < items.Count)
            {
                Sprite sprite = items[i].itemSprite;               
                image.sprite = sprite;
            } else
            {
                image.sprite = null;    
            }
           
        }
    }
    private void ListInit()
    {
        items.Clear();
        
        for (int i = 0; i < shopData.GetBuyList().Count; i++)
        {
            if (InventoryManager.Instance == null) return; // prevent this method call before set instance of InventoryManager
            if (!InventoryManager.Instance.inventoryStorage.IsEnoughItem(shopData.GetBuyList()[i].itemType, 1)) continue;
            items.Add(shopData.GetBuyList()[i]);
        }

    }
    private void AddListener()
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (!UIContent.GetChild(i).TryGetComponent<Button>(out Button button))
            {
                Debug.Log("null button component");
                return; 
            }

            button.onClick.AddListener(delegate { SetSelectedIndex(button.transform.GetSiblingIndex()); });
            
        }
    }
    private void RemoveListener()
    {
        foreach(Transform slot in UIContent)
        {
            if (!slot.TryGetComponent<Button>(out Button button)) continue; 
            button.onClick.RemoveAllListeners();
        }
    }
    private void SetSelectedIndex(int index)
    {
        currentSelectedIndex = index;
        Debug.Log(currentSelectedIndex);
       
    }
    public virtual ScriptableObject_Items GetSelectedItem() { return null; }
   
   
    public int GetCurrentIndex()
    {
        return currentSelectedIndex;    
    }
}
