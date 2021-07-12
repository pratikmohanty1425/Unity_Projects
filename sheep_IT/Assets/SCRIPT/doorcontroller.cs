using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorcontroller : MonoBehaviour
{
    private Transform[] childern;

    public bool deactivatedoor =false ;

    public static doorcontroller instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        childern = transform.GetComponentsInChildren<Transform>();
        if(deactivatedoor)
        {
            opendoor();
        }
    }

    public void opendoor()
    {
        foreach(Transform c in childern)
        {
            if(c.CompareTag("door"))
            {
                Debug.Log("done");
                c.gameObject.GetComponent<Collider>().isTrigger = true;
            }
        }
    }
}
