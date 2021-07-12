using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    //private Vector3 center;

    void Start()
    {
        //center = transform.position;
        StartCoroutine("create");
    }

    IEnumerator create()
    {
        Vector3 pos = Random.onUnitSphere * 200f;
        Instantiate(enemy, pos, Quaternion.identity);
        int ran = Random.Range(0, 2);
        yield return new WaitForSeconds(ran);
        //Vector3 pos = RandomCircle(center, 100.0f);
        //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
        //Instantiate(enemy, pos, rot);
        StartCoroutine("create");
    }

    //Vector3 RandomCircle(Vector3 center, float radius)
    //{
    //    int ang = Random.Range(0,360);
    //    Vector3 pos;
    //    pos.x = center.x + radius * Mathf.Sin(ang );
    //    pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
    //    pos.z = center.z + radius * Mathf.Cos(ang);
    //    return pos;
    //}

}
