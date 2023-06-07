using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    private HotbarStorage hotbarStorage;
    public static HotbarManager Instance { get; private set; }
    public GameObject test;
    private void Awake()
    {
        Instance = this;
        hotbarStorage = GetComponentInChildren<HotbarStorage>();
    }

    /// <summary>
    /// this item is special item such as seeds, fertilizer it do not stored in inventory list
    /// </summary>
    public void AddItem()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
        InventoryManager.Instance.PickUpItem(test);   

        }
    }


}
