using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    MapSpawner mapSpawner;
    void Start()
    {
        mapSpawner = GetComponent<MapSpawner>();
    }


    public void SpawnTriggerEntered()
    {
        mapSpawner.SpawnRoad();
    }
}
