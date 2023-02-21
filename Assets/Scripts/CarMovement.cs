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
        //if (!car0moving && Vector3.Distance(road.transform.position, Player.Instance.GetPosition()) < 200f)
        //{
        //    cars[0].transform.localPosition = Vector3.MoveTowards(cars[0].transform.position, pathPoints[0].position, speed * Time.deltaTime);
        //    car0moving = true;
        //}

        if (!car1moving && Vector3.Distance(road.transform.position, Player.Instance.GetPosition()) < 10)
        {
            Vector3 newPos = cars[1].transform.localPosition + new Vector3(0, 0, 150f);
            cars[1].transform.localPosition = Vector3.MoveTowards(cars[1].transform.localPosition, newPos, speed * Time.deltaTime);
            car1moving = true;
        }

        //if (!car2moving && Vector3.Distance(road.transform.position, Player.Instance.GetPosition()) < 150)
        //{
        //    cars[2].transform.localPosition = Vector3.MoveTowards(cars[2].transform.localPosition, pathPoints[0].localPosition, speed * Time.deltaTime);
        //    car2moving = true;
        //}
    }


}
