using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform spawn;
    public GameObject knife;
    
    public void spknife()
    {
        Instantiate(knife, spawn.position, spawn.rotation);
        //GameObject go = Instantiate(knife, spawn.position, spawn.rotation);
        //go.transform.parent = gameObject.transform;
    }
}
