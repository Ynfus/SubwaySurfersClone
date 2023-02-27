using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class MysteryItem : MonoBehaviour
{
    public static MysteryItem Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

        Transform child = gameObject.transform.GetChild(Random.Range(0, gameObject.transform.childCount));
        Transform grandchild = child.transform.GetChild(0);
        child.gameObject.SetActive(true);
        grandchild.gameObject.SetActive(true);






    }
    //private void Update()
    //{
    //    StartCoroutine(CoinMagnetCoroutine());

    //}
    public void ActivateCoinMagnet()
    {
        StartCoroutine(CoinMagnetCoroutine());
    }

    private IEnumerator CoinMagnetCoroutine()
    {
        //Debug.Log("Coin Magnet a1ctivated");
        //float magnetRadius = 10f;
        //float magnetDuration = 15000f;
        //Collider[] colliders = Physics.OverlapSphere(Player.Instance.GetPosition(), magnetRadius);

        //foreach (Collider collider in colliders)
        //{
        //    Debug.Log(collider.gameObject.layer + "eee");
        //    if (collider.gameObject.layer == LayerMask.NameToLayer("Coin"))
        //    {
        //        CoinsCounter.Instance.IncreaseCoinsAmount();
        //        collider.gameObject.SetActive(false);
        //    }
        //}

        //yield return new WaitForSeconds(magnetDuration);

        float magnetRadius = 12f;
        float magnetDuration = 15f;
        float elapsedTime = 0f;

        while (elapsedTime < magnetDuration)
        {
            Collider[] colliders = Physics.OverlapSphere(Player.Instance.GetPosition(), magnetRadius);
            Debug.Log("12 999");

            foreach (Collider collider in colliders)
            {
                Debug.Log("123 999");

                if (collider.gameObject.layer == LayerMask.NameToLayer("Coin"))
                {
                    Debug.Log("1234 999");
                    CoinsCounter.Instance.IncreaseCoinsAmount();
                    collider.gameObject.SetActive(false);
                }
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

    }

}
