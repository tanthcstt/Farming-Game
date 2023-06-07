using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public CoinUI coinUI;
    public int Coin { get; private set; }
    public static CoinManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {
        UpdateCoin(100);
    }

    public void UpdateCoin(int coin)
    {
        Coin = coin;    
        coinUI.SetCoinUI(coin); 
    }

    public bool IsEnoughCoin(int amount)
    {
        return Coin >= amount;
    }
}
