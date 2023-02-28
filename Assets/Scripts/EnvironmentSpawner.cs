using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    public GameObject player;
    private float zPosChange = 620f;
    [SerializeField] List<GameObject> spawnedPlots;


    private int initAmount = 16;
    private float plotSize = 40f;
    private float xPosLeft = -71.5f;
    private float xPosRight = 71.5f;
    private float lastZPos = -20f;
    private bool isAfterStart = false;
    private bool isFirstSpawned = false;
    public List<GameObject> plots;
    private GameObject lastPlotR;
    private GameObject lastPlotL;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initAmount; i++)
        {
            SpawningLogic();
        }

    }

    private void SpawningLogic()
    {
        //GameObject plotL = null;
        //GameObject plotR = null;

        //while (plotL == null || plotR == null || plotL == lastPlotL || plotR == lastPlotR || plotL == plotR)
        //{
        //    plotL = plots[Random.Range(0, plots.Count)];
        //    plotR = plots[Random.Range(0, plots.Count)];
        //}

        //float zPos = lastZPos + plotSize;
        //Instantiate(plotL, new Vector3(xPosLeft, 0, zPos), plotL.transform.rotation);
        //Instantiate(plotR, new Vector3(xPosRight, 0, zPos), new Quaternion(0, 180, 0, 0));
        //spawnedPlots.Add(plotL);
        //spawnedPlots.Add(plotR);
        //if (lastPlotL != null && lastPlotR != null && (lastPlotL != plotL || lastPlotR != plotR))
        //{
        //    plots.Add(lastPlotL);
        //    plots.Add(lastPlotR);

        //}

        //lastPlotL = plotL;
        //lastPlotR = plotR;
        //lastZPos += plotSize;

        //plots.Remove(plotL);
        //plots.Remove(plotR);
        GameObject plotL = null;
        GameObject plotR = null;

        while (plotL == null || plotR == null || plotL == lastPlotL || plotR == lastPlotR || plotL == plotR)
        {
            plotL = plots[Random.Range(0, plots.Count)];
            plotR = plots[Random.Range(0, plots.Count)];
        }

        float zPos = lastZPos + plotSize;
        GameObject plotLInstance = Instantiate(plotL, new Vector3(xPosLeft, 0, zPos), plotL.transform.rotation);
        GameObject plotRInstance = Instantiate(plotR, new Vector3(xPosRight, 0, zPos), new Quaternion(0, 180, 0, 0));

        if (lastPlotL != null && lastPlotR != null && (lastPlotL != plotL || lastPlotR != plotR))
        {
            plots.Add(lastPlotL);
            plots.Add(lastPlotR);
        }

        lastPlotL = plotL;
        lastPlotR = plotR;
        lastZPos += plotSize;
        spawnedPlots.Add(plotLInstance);
        spawnedPlots.Add(plotRInstance);
        plots.Remove(plotL);
        plots.Remove(plotR);
    }

    void Update()
    {
        Debug.Log(spawnedPlots.Count+"counts");
        foreach (GameObject plot in spawnedPlots)
        {
            Debug.Log(plot.transform.position.z + "!123");
            if (player.transform.position.z - plotSize > plot.transform.position.z)
            {
                plot.transform.position += new Vector3(0f, 0f, zPosChange);
            }

        }
    }

}
