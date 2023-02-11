using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotSpawner : MonoBehaviour
{
    private int initAmount = 5;
    private float plotSize = 200f;
    private float xPosLeft = -22f;
    private float xPosRight = 22f;
    private float lastZPos = 14f;
    public List<GameObject> plots;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initAmount; i++)
        {
            SpawnPlot();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnPlot()
    {
        GameObject plotL = plots[Random.Range(0, plots.Count)];
        GameObject plotR = plots[Random.Range(0, plots.Count)];
        float zPos = lastZPos + plotSize;
        Instantiate(plotL, new Vector3(xPosLeft, 0, zPos), plotL.transform.rotation);
        Instantiate(plotR, new Vector3(xPosRight, 0, zPos), new Quaternion(0, 180, 0, 0));
        lastZPos += plotSize;

    }
}
