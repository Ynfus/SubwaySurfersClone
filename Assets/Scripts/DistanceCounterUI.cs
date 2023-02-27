using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Player player;
    public static DistanceCounter Instance;

    private float startingPosition;
    private float distance;
    private float distanceFromLast;
    private float lastPosition;
    private bool doublePoints = false;
    private float doublePointsActiveTime = 15f;
    private float doublePointsTimer = 0f;

    private void Start()
    {
        Instance= this;
        startingPosition = player.transform.position.z;
    }

    private void Update()
    {
        
        distanceFromLast =  (player.transform.position.z- startingPosition)  -lastPosition;
        if (doublePoints)
        {
            distance += distanceFromLast * 20;
            doublePointsTimer -= Time.deltaTime;
            if (doublePointsTimer <= 0f)
            {
                doublePoints = false;
            }
        }
        lastPosition = player.transform.position.z - startingPosition;
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
