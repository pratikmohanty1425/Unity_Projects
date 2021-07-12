using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravityattractor : MonoBehaviour
{
    public float gravity = -9.8f;
    
    public void Attract(Transform body)
    {
        Vector3 distance = (body.position - transform.position).normalized;
        Vector3 localup = body.up;

        body.GetComponent<Rigidbody>().AddForce(distance * gravity);

        Quaternion targetrotation = Quaternion.FromToRotation(localup, distance) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetrotation, 500 * Time.deltaTime);
    }
}
