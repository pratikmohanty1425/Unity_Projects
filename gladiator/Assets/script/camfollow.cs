using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollow : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    private Vector3 offset;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        follow();
    }

    void follow()
    {
        
        transform.position = target.TransformPoint(offset);
        
        transform.rotation = target.rotation;
    }
}
