using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    private TextMeshProUGUI count;
    private void Awake()
    {
        LoadComponent();
    }
    private void LoadComponent()
    {
        count = GetComponentInChildren<TextMeshProUGUI>();  
    }

    public void SetCoinUI(int amount)
    {
        count.text = amount.ToString(); 
    }
}
