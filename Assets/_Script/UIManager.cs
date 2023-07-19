using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public GameObject farmingShop;
    public GameObject craftingUI;
    [SerializeField] private GameObject placeObjUI;
    public GameObject joystickUI;
    public GameObject machineShop;
    private void Awake()
    {
        Instance = this;    
    }
    private void Start()
    {
        farmingShop.SetActive(false);   
        craftingUI.SetActive(false);
        placeObjUI.SetActive(false);
        machineShop.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) farmingShop.SetActive(!farmingShop.activeSelf);
    }
    public void ToggleUI(GameObject UI)
    {
        UI.SetActive(!UI.activeSelf);       
    }
   
  
}
