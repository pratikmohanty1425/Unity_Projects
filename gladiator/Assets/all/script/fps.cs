using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps : MonoBehaviour
{
    public Transform p;
    public float sensitivity = 100f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    float xr = 0f;
    float yr = 0f;


    void Update()
    {

        float mx = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        float my = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        xr -= my;
        xr = Mathf.Clamp(xr, -90f, 90f);
        yr += mx;
        yr = Mathf.Clamp(yr, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xr, yr, 0f);
        p.Rotate(Vector3.up * mx);
    }
}
