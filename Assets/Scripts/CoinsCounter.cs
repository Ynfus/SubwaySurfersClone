using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsCounter : MonoBehaviour
{
    public static CoinsCounter Instance;
    private int coins=0;
    [SerializeField] TextMeshProUGUI coinsAmountText;
    private int coinsAmount = 0;

    private void Start()
    {
        UpdateCoins();
    }
    private void UpdateCoins()
    {
        coinsAmount = CoinsCounter.Instance.GetCoinsAmount();
        coinsAmountText.text = coinsAmount.ToString("F0");
    }

    private void Awake()
    {
        Instance= this;
    }
    public void IncreaseCoinsAmount()
    {
        coins++;
        UpdateCoins();
    }
    public int GetCoinsAmount()
    {
        return coins;
    }
    public void ResetCoins()
    { 
        coins= 0;
    }
}
