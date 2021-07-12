using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enemyspwaner : MonoBehaviour
{
    public GameObject enemyplane;
    public GameObject[] astroids;

    public float minx= -1.92f, maxx= 1.92f, miny=-5;

    public float timer=2;

    private void Start()
    {
        Invoke("spawner", timer);
    }

    void spawner()
    {
        float posx = Random.Range(minx, maxx);
        Vector3 temp = transform.position;
        temp.x = posx;
        if(Random.Range(0,2)>0)
        {
            Instantiate(astroids[Random.Range(0, astroids.Length)], temp, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyplane, temp, Quaternion.Euler(0,0,180));
        }
        Invoke("spawner", timer);
    }
}
