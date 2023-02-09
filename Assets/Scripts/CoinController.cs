using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinController : MonoBehaviour
{

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                CoinsCounter.Instance.IncreaseCoinsAmount();
                Destroy(gameObject);
                Debug.Log("werwerwef");
            }
        }
    }
}
