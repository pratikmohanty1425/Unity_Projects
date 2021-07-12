using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour
{
    private float smoothmovingspeed = 15f;
    public float rotationsmooting = 14;

    private Transform target;

    private Vector3 targetforward;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        targetforward = transform.forward;
        targetforward.y = 0;
        Snap();
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }

    void Snap()
    {
        if(target != null)
        {
            transform.position = target.position;
        }
        Vector3 forward = targetforward;
        forward.y = transform.forward.y;
        transform.forward = forward;
    }

    void follow()
    {
        if(target != null)
        {
            transform.position =
                Vector3.Lerp(transform.position,
                target.position, Time.deltaTime * smoothmovingspeed);
        }
        Vector3 forward = transform.forward;
        forward.y = 0;
        forward = Vector3.Slerp(forward ,
            targetforward, Time.deltaTime * rotationsmooting);
        forward.y = transform.forward.y;
        transform.forward = forward;
    }

}
