using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    public int initialAmount = 5;
    public float plotSize = 40f;
    public GameObject player;

    private float lastZPosLeft=220f;
    private float lastZPosRight=220f;
    [SerializeField] List<GameObject> spawnedPlots;

    void Update()
    {
        foreach (GameObject plot in spawnedPlots)
        {
            if (player.transform.position.z - 40 > plot.transform.position.z && plot.transform.position.x > 0)
            {
                lastZPosLeft += 40;
                plot.transform.Translate(0, 0, lastZPosLeft);
            }
            if (player.transform.position.z - 40 > plot.transform.position.z && plot.transform.position.x < 0)
            {
                lastZPosRight += 40;
                plot.transform.Translate(0, 0, lastZPosRight);

                // Dodaj korektê rotacji w przypadku prefabu obróconego o 180 stopni
                plot.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
    }


}
