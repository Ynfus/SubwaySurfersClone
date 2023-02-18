using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotSpawner : MonoBehaviour
{
    private int initAmount = 8;
    private float plotSize = 40f;
    private float xPosLeft = -64f;
    private float xPosRight = 64f;
    private float lastZPos = 14f;
    private bool isAfterStart=false;
    public List<GameObject> plots;
    public List<GameObject> lastPlots = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initAmount; i++)
        {
            SpawnPlot();
        }
        isAfterStart= true;
    }

    public void SpawnPlot()
    {
        if (isAfterStart)
        {
            for (int i = 0; i < 3; i++)
            {
                SpawningLogic();
            }
        }
        else SpawningLogic();



    }
    private void SpawningLogic()
    {
        GameObject plotL = null;
        GameObject plotR = null;
        bool isPlotFound = false;

        while (!isPlotFound)
        {
            plotL = plots[Random.Range(0, plots.Count)];
            plotR = plots[Random.Range(0, plots.Count)];

            // SprawdŸ, czy wylosowane obiekty s¹ ró¿ne i czy nie znajduj¹ siê ju¿ na liœcie ostatnio wylosowanych obiektów
            if (plotL != plotR && !lastPlots.Contains(plotL) && !lastPlots.Contains(plotR))
            {
                isPlotFound = true;
                lastPlots.Add(plotL);
                lastPlots.Add(plotR);
            }
        }

        float zPos = lastZPos + plotSize;
        Instantiate(plotL, new Vector3(xPosLeft, 0, zPos), plotL.transform.rotation);
        Instantiate(plotR, new Vector3(xPosRight, 0, zPos), new Quaternion(0, 180, 0, 0));
        lastZPos += plotSize;














        //GameObject plotL = plots[Random.Range(0, plots.Count)];
        //GameObject plotR = plots[Random.Range(0, plots.Count)];
        //float zPos = lastZPos + plotSize;
        //Instantiate(plotL, new Vector3(xPosLeft, 0, zPos), plotL.transform.rotation);
        //Instantiate(plotR, new Vector3(xPosRight, 0, zPos), new Quaternion(0, 180, 0, 0));
        //lastZPos += plotSize;


    }
}
