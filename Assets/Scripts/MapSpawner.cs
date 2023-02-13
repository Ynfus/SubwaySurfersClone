using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    private int initAmount = 1;
    private float roadSize = 200f;
    private float lastZPos = 100f;
    public List<GameObject> roads;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initAmount; i++)
        {
            SpawnRoad();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnRoad()
    {

        GameObject road = roads[Random.Range(0, roads.Count)];
        float zPos = lastZPos + roadSize;
        Instantiate(road, new Vector3(0, 0, zPos), road.transform.rotation);
        lastZPos += roadSize;

    }
}
