using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHotbarSelection : MonoBehaviour
{
    
    public Transform hotbarContent;


    private void Start()
    {      

        AddSlotListener();
    }
    private void Update()
    {
       ChangeCurrentSelectionUI(InputManager.Instance.HotbarSelection);
    }
 
    private void AddSlotListener()
    {
        foreach (Transform slot in hotbarContent)
        {
            Button btn = slot.GetComponent<Button>();
            btn.onClick.AddListener(delegate { ClickChangeSelection(btn.transform.GetSiblingIndex()); });
        }
    }
    private void ClickChangeSelection(int newSelection)
    {       
        InputManager.Instance.SetHotbarSelectingByClick(newSelection);
        ChangeCurrentSelectionUI(newSelection);
    }

    private void ChangeCurrentSelectionUI(int newSelection)
    {    
        GameObject selecting;
        for (int i = 0; i < hotbarContent.childCount; i++)
        {
            selecting = hotbarContent.GetChild(i).Find("Selecting").gameObject;
            if (i == newSelection) 
            {
                selecting.SetActive(true);
            } else
            {
                selecting.SetActive(false);
            }

        }
    }

}
