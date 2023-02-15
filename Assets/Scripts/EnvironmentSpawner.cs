using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{

    [SerializeField] private GameObject prefab;  // Prefab obiektów, które bêd¹ przechowywane w puli.
    [SerializeField] private int poolSize = 10;  // Pocz¹tkowy rozmiar puli.

    private List<GameObject> pool;  // Lista przechowuj¹ca obiekty w puli.

    // Metoda wywo³ywana przy starcie.
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

    // Metoda zwracaj¹ca obiekt z puli.
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

        // W przypadku braku wolnych obiektów w puli, utworzenie nowego.
        GameObject newObj = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
        pool.Add(newObj);
        return newObj;
    }
}
