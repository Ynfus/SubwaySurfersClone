using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Player player;
    private Vector3 startingPosition;
    private float distance;

    private void Start()
    {
        startingPosition = player.transform.position;
    }

    private void Update()
    {
        distance = Vector3.Distance(startingPosition, player.transform.position);
        scoreText.text = distance.ToString();
        // wyœwietl wartoœæ dystansu na ekranie
    }
}
