using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public GameObject farmingShop;
    private void Awake()
    {
        Instance = this;    
    }
    private void Start()
    {
        farmingShop.SetActive(false);   
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) farmingShop.SetActive(!farmingShop.activeSelf);
    }
}
