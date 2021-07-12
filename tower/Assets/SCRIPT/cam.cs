using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    [HideInInspector]
    public Vector3 targetpos;
    private void Start()
    {
        targetpos = transform.position;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetpos, 0.25f * Time.deltaTime);
    }
}
