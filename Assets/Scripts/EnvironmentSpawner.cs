using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    public int initialAmount = 5;
    public float plotSize = 40f;
    public GameObject[] plotPrefabs;
    public GameObject player;
    public float despawnDistance = 100f;

    private float lastZPos;
    private List<GameObject> spawnedPlots;

    void Start()
    {
        lastZPos = plotSize * initialAmount;

        // Spawn initial plots
        spawnedPlots = new List<GameObject>();
        for (int i = 0; i < initialAmount; i++)
        {
            SpawnPlot();
        }
    }

    void Update()
    {
        // Check if any spawned plots are outside the despawn distance
        for (int i = spawnedPlots.Count - 1; i >= 0; i--)
        {
            GameObject plot = spawnedPlots[i];
            if (plot.transform.position.z < player.transform.position.z - despawnDistance)
            {
                // Move plot to the end
                plot.transform.position += new Vector3(0, 0, plotSize * initialAmount);

                // Remove plot from the beginning of the list and add it to the end
                spawnedPlots.RemoveAt(i);
                spawnedPlots.Add(plot);
            }
        }
    }

    private void SpawnPlot()
    {
        // Spawn a random plot prefab
        GameObject plot = Instantiate(plotPrefabs[Random.Range(0, plotPrefabs.Length)]);

        // Set position to last z position
        plot.transform.position = new Vector3(plot.transform.position.x, plot.transform.position.y, lastZPos);

        // Update last z position
        lastZPos += plotSize;

        // Add plot to spawned plots list
        spawnedPlots.Add(plot);
    }
}
