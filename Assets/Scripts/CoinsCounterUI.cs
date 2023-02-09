using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsCounterUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsAmountText;
    private int coinsAmount=0;


    private void Update()
    {
        coinsAmount = CoinsCounter.Instance.GetCoinsAmount();
        coinsAmountText.text =coinsAmount.ToString("F0");
        // wyœwietl wartoœæ dystansu na ekranie
    }
}
