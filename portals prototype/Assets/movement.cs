using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 3f;

    public CharacterController c;
    Vector3 VEL;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 m = transform.right * x + transform.forward * y;

        c.Move(m * speed * Time.deltaTime);

        VEL.y += -9.8f + Time.deltaTime;
        c.Move(VEL * Time.deltaTime);

    }
}
