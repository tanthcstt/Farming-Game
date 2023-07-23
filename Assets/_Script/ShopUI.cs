using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShopUI : MonoBehaviour
{
    protected Button submitBtn;
    protected TextMeshProUGUI price;
    protected Transform content;
    [SerializeField] protected Sprite selectedUI;
    [SerializeField] protected Sprite unSelectedUI;
    protected int prevSelection = 0;   
    protected int selectedSlot = 0;
   
   
    public virtual void Start()
    {
        LoadComponent();
        AddListener();
        LoadImage();
        UpdateSelectedUI(0);

    }
    public virtual void LoadComponent()
    {
        GameObject btn = transform.Find("Submit").gameObject;
        submitBtn = btn.GetComponent<Button>();
        price = btn.GetComponentInChildren<TextMeshProUGUI>();      
        content = transform.Find("Content");
              
     
    }
    protected void AddListener()
    {
        submitBtn.onClick.AddListener(OnSubmit);
        foreach (Transform slot in content)
        {
            if (slot.TryGetComponent<Button>(out Button btn))
            {
                btn.onClick.AddListener(delegate {

                    int slotIndex = slot.GetSiblingIndex();
                    SelectItem(slotIndex); 
                    UpdatePriceButton();
                    UpdateSelectedUI(slotIndex);
                    
                });  
            }
        }
    }
    protected void UpdateSelectedUI(int currentSelection)
    {        

        if (content.GetChild(prevSelection).TryGetComponent<Image>(out Image prevImg))
        {
            prevImg.sprite = unSelectedUI;
        }

        if (content.GetChild(currentSelection).TryGetComponent<Image>(out Image currentImg))
        {
            currentImg.sprite = selectedUI;
        }

        prevSelection = currentSelection;
    }
    public virtual void SelectItem(int selectedSlot)
    {
        if (selectedSlot >= GetSprite().Count) return;
        this.selectedSlot = selectedSlot;       
    }
    public virtual void UpdatePriceButton()
    {
        price.text = GetPrice(selectedSlot).ToString();
    }
    protected  void LoadImage() 
    {
        for (int i = 0; i < GetSprite().Count; i++)
        {
            Transform imgTransform = content.GetChild(i).GetChild(0);    
            if (!imgTransform.TryGetComponent<Image>(out Image img)) continue;
            img.sprite = GetSprite()[i];
          
        }

    }
    protected abstract List<Sprite> GetSprite();
    protected virtual int GetPrice(int index) { return 0; }

    public abstract void OnSubmit();
   
}
