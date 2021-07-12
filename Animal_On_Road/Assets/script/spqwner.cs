using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spqwner : MonoBehaviour
{
    public GameObject[] cars;
    void Start()
    {
        
    }
    float timer;
    public float delay = 0.85f;
    int i;
    void Update()
    {
        i = Random.Range(0,cars.Length);
        if(timer<=Time.time)
        {
            Instantiate(cars[i],transform.position,cars[i].transform.rotation);
            timer = Time.time + delay;
        }
    }
    
}
