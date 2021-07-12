using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform t;
    private Vector3 offset;

    void Awake()
    {
        offset = transform.position - t.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = t.position + offset;
    }
}
