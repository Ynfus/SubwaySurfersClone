using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 5f;
    public Transform[] pathPoints;
    [SerializeField] GameObject road;
    [SerializeField] GameObject[] cars;
    private bool car0moving = false;
    private bool car1moving = false;
    private bool car2moving = false;

    private int currentPointIndex = 0;

    void Update()
    {
        speed=Player.Instance.GetSpeed();
        if (Vector3.Distance(road.transform.position, Player.Instance.GetPosition()) < 50)
        {
            Vector3 newPos = cars[0].transform.localPosition + new Vector3(0, 0, -150f);
            cars[0].transform.localPosition = Vector3.MoveTowards(cars[0].transform.localPosition, newPos, speed * Time.deltaTime);

        }
        Debug.Log(Vector3.Distance(road.transform.position, Player.Instance.GetPosition()));
        if (Vector3.Distance(road.transform.position, Player.Instance.GetPosition()) < 150)
        {
            Vector3 newPos = cars[1].transform.localPosition + new Vector3(0, 0, -150f);
            cars[1].transform.localPosition = Vector3.MoveTowards(cars[1].transform.localPosition, newPos, speed * Time.deltaTime);
            
        }

        if (Vector3.Distance(road.transform.position, Player.Instance.GetPosition()) < 100)
        {
            Vector3 newPos = cars[2].transform.localPosition + new Vector3(0, 0, -150f);
            cars[2].transform.localPosition = Vector3.MoveTowards(cars[2].transform.localPosition, newPos, speed * Time.deltaTime);

        }
    }


}
