using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 5f;
    public Transform[] pathPoints; 
    public Player player;

    private int currentPointIndex = 0; 

    void Update()
    {
        Debug.Log(player.GetPosition()+"hvuyittiftfftu");
        //if (true)
        //{

        //}
        //transform.position = Vector3.MoveTowards(transform.position, pathPoints[currentPointIndex].position, speed * Time.deltaTime);

    }
}
