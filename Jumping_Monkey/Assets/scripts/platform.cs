using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField]
    private GameObject banana=null,bananas=null;

    [SerializeField]
    private Transform spawnpoint=null;

    void Start()
    {
        GameObject newb = null;
        if(Random.Range(0,8)>3)
        {
            newb = Instantiate(banana, spawnpoint.position, Quaternion.identity);
        }
        else
        {
            newb = Instantiate(bananas, spawnpoint.position, Quaternion.identity);
        }

        newb.transform.parent = transform;
    }

}
