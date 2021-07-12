using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watermovment : MonoBehaviour
{
    public float speed = 0.5f;

    void Update()
    {
        transform.position = new Vector3(Mathf.Cos(Time.time), Mathf.Sin(Time.time))*speed;
    }
}
