using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCounter : MonoBehaviour
{
    public static CoinsCounter Instance;
    private int coins=0;

    private void Awake()
    {
        Instance= this;
    }
    public void IncreaseCoinsAmount()
    {
        coins++;
        Debug.Log(coins);
    }
    public int GetCoinsAmount()
    {
        return coins;
    }
}
