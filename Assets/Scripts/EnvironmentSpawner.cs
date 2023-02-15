using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{

    [SerializeField] private GameObject prefab;  // Prefab obiekt�w, kt�re b�d� przechowywane w puli.
    [SerializeField] private int poolSize = 10;  // Pocz�tkowy rozmiar puli.

    private List<GameObject> pool;  // Lista przechowuj�ca obiekty w puli.

    // Metoda wywo�ywana przy starcie.
    private void Start()
    {
        // Inicjalizacja puli.
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    // Metoda zwracaj�ca obiekt z puli.
    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // W przypadku braku wolnych obiekt�w w puli, utworzenie nowego.
        GameObject newObj = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
        pool.Add(newObj);
        return newObj;
    }
}
