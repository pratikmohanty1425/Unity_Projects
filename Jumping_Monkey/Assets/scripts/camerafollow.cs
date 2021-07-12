using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    private Transform target;

    private bool followplayer;

    public float miny = -2.65f;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        follow();
    }

    void follow()
    {
        if (target.position.y < (transform.position.y - miny))
        {
            followplayer = false;
        }

        if (target.position.y > transform.position.y )
        {
            followplayer = true;
        }

        if(followplayer)
        {
            Vector3 temp = transform.position;
            temp.y = target.position.y;
            transform.position = temp;
        }
    }
}
