using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    MapSpawner mapSpawner;
    PlotSpawner plotSpawner;

    // Start is called before the first frame update
    void Start()
    {
        plotSpawner = GetComponent<PlotSpawner>();
        mapSpawner = GetComponent<MapSpawner>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnTriggerEntered()
    {
        Debug.Log("Spawned");
        mapSpawner.SpawnRoad();
        plotSpawner.SpawnPlot();
    }
}
