using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
   
    public static InputManager Instance { get; private set; }
    public KeyCode interactingKey = KeyCode.Space;
    private readonly KeyCode[] hotbarKey =
    {       
       // KeyCode.Alpha0,
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
    };
    public int HotbarSelection { get; private set; }
    public GameObject player;
    

    private void Awake()
    {
        Instance = this;
        HotbarSelection = 0;
       
    }
    private void Update()
    {
        UpdateHobarSelecting();
    }
    public bool IsMovingKeyPress()
    {
        float vertical = Input.GetAxis("Vertical");
        float horzontal = Input.GetAxis("Horizontal");
        return (vertical != 0 || horzontal != 0);
    }
  
    // return index of hotbar key pressed to set state or ui
    private void UpdateHobarSelecting()
    {
        for (int i = 0; i < hotbarKey.Length; i++)
        {
            if (Input.GetKeyDown(hotbarKey[i]))
            {
                HotbarSelection = i;              
                return;
            }
        }
                
    }
    public void SetHotbarSelectingByClick(int selectingIndex)
    {
        HotbarSelection = selectingIndex;
    }

}
