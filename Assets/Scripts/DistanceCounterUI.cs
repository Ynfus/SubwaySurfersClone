using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Player player;
    public static DistanceCounter Instance;

    private Vector3 startingPosition;
    private float distance;

    private void Start()
    {
        Instance= this;
        startingPosition = player.transform.position;
    }

    private void Update()
    {
        distance = Vector3.Distance(startingPosition, player.transform.position);
        scoreText.text = distance.ToString("F0");
        // wyœwietl wartoœæ dystansu na ekranie
    }
    public string GetDistanceAmount()
    {
        return distance.ToString("F0");
    }
    public void ResetDistance()
    { 
        distance= 0;
    
    }
}
