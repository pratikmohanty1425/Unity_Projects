using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GameObject attractor;
    private Transform mytransform;

    void Start()
    {
        mytransform = this.GetComponent<Transform>();
        attractor = GameObject.Find("Ground");
        GetComponent<Rigidbody>().useGravity = false;
    }

    void Update()
    {
        if (attractor)
        {
            attractor.GetComponent<Gravityattractor>().Attract(mytransform);
        }
    }
}
