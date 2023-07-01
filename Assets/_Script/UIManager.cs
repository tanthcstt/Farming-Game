using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public GameObject farmingShop;
    [SerializeField] private GameObject craftingUI;
    private void Awake()
    {
        Instance = this;    
    }
    private void Start()
    {
        farmingShop.SetActive(false);   
        craftingUI.SetActive(false);
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
