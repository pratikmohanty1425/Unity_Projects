using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwaner : MonoBehaviour
{
    public GameObject block;
    public void spawnbox()
    {
        Instantiate(block, transform.position, Quaternion.identity);
    }
}
