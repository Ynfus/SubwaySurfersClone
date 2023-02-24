using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotSpawner : MonoBehaviour
{
    //private int initAmount = 8;
    //private float plotSize = 40f;
    //private float xPosLeft = -71.5f;
    //private float xPosRight = 71.5f;
    //private float lastZPos = 14f;
    //private bool isAfterStart = false;
    //private bool isFirstSpawned = false;
    //public List<GameObject> plots;
    //private GameObject lastPlotR;
    //private GameObject lastPlotL;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    for (int i = 0; i < initAmount; i++)
    //    {
    //        SpawnPlot();
    //    }
    //    isAfterStart = true;
    //}

    //public void SpawnPlot()
    //{
    //    if (isAfterStart)
    //    {
    //        for (int i = 0; i < 3; i++)
    //        {
    //            SpawningLogic();
    //        }
    //    }
    //    else SpawningLogic();
    //}
    //private void SpawningLogic()
    //{
    //    GameObject plotL = null;
    //    GameObject plotR = null;

    //    while (plotL == null || plotR == null || plotL == lastPlotL || plotR == lastPlotR || plotL == plotR)
    //    {
    //        plotL = plots[Random.Range(0, plots.Count)];
    //        plotR = plots[Random.Range(0, plots.Count)];
    //    }

    //    float zPos = lastZPos + plotSize;
    //    Instantiate(plotL, new Vector3(xPosLeft, 0, zPos), plotL.transform.rotation);
    //    Instantiate(plotR, new Vector3(xPosRight, 0, zPos), new Quaternion(0, 180, 0, 0));

    //    if (lastPlotL != null && lastPlotR != null && (lastPlotL != plotL || lastPlotR != plotR))
    //    {
    //        plots.Add(lastPlotL);
    //        plots.Add(lastPlotR);
    //    }

    //    lastPlotL = plotL;
    //    lastPlotR = plotR;
    //    lastZPos += plotSize;

    //    plots.Remove(plotL);
    //    plots.Remove(plotR);
    //}







    //isFirstSpawned= true;
    //GameObject plotL = plots[Random.Range(0, plots.Count)];

    //GameObject plotR = plots[Random.Range(0, plots.Count)];

    //float zPos = lastZPos + plotSize;
    //Instantiate(plotL, new Vector3(xPosLeft, 0, zPos), plotL.transform.rotation);
    //Instantiate(plotR, new Vector3(xPosRight, 0, zPos), new Quaternion(0, 180, 0, 0));
    //if (isFirstSpawned)
    //{
    //    plots.Add(plotL);
    //    plots.Add(plotR);
    //}
    //lastZPos += plotSize;
    //lastPlotR = plotR;
    //plots.Remove(plotR);
    //lastPlotL = plotL;
    //plots.Remove(plotL);
    //}
}
