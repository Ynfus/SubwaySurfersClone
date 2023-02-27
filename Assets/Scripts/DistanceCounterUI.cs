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
    private float distanceFromLast;
    private bool doublePoints = false;
    private float doublePointsActiveTime = 15f;
    private float doublePointsTimer = 0f;

    private void Start()
    {
        Instance= this;
        startingPosition = player.transform.position;
    }

    private void Update()
    {
        
        distanceFromLast = Vector3.Distance(startingPosition, player.transform.position)-distance;
        if (doublePoints)
        {
            distance += distanceFromLast * 200;
            doublePointsTimer -= Time.deltaTime;
            if (doublePointsTimer <= 0f)
            {
                doublePoints = false;
            }
        }
        distance += distanceFromLast;
        Debug.Log(distance+"   "+ player.transform.position+"     "+distanceFromLast);

        scoreText.text = distance.ToString("F0");
    }
    public string GetDistanceAmount()
    {
        return distance.ToString("F0");
    }
    public void ResetDistance()
    { 
        distance= 0;
    
    }
    public void ActivateDoublePoints()
    {
        doublePoints = true;
        doublePointsTimer = doublePointsActiveTime;
    }
}
