using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGoal : MonoBehaviour
{
    Vector3 pointA = new Vector3(15, 0, -9.5f);
    Vector3 pointB = new Vector3(-15, 0, -9.5f);
    void Update()
    {
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
    }
}


