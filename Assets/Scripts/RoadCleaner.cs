using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCleaner : MonoBehaviour
{
    [SerializeField] private Player player;

    public float deleteDistance = 110f;

    private void Update()
    {
        CleanUpRoads();
    }

    private void CleanUpRoads()
    {
        GameObject[] roads = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject road in roads)
        {
            if (road.transform.position.z < player.transform.position.z - deleteDistance)
            {
                Destroy(road);
            }
        }
    }
}
