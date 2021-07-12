using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road : MonoBehaviour
{
    public GameObject roadp;
    public Vector3 lastpos;
    public float offset = 0.707f;

    private int roadcnt = 0;
    private void Awake()
    {
        InvokeRepeating("createroad", 1f, 0.5f);
    }
    public void createroad()
    {
        Debug.Log("created");
        Vector3 sp = Vector3.zero;
        float chance = Random.Range(0, 100);
        if(chance<50)
        {
            sp = new Vector3(lastpos.x + offset, 0, lastpos.z + offset);
        }
        else
        {
            sp = new Vector3(lastpos.x - offset, 0, lastpos.z + offset);
        }
        GameObject g = Instantiate(roadp, sp, Quaternion.Euler(0, 45, 0));
        lastpos = g.transform.position;
        roadcnt++;
        if (roadcnt % 5 == 0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
