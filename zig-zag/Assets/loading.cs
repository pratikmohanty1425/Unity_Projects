using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loading : MonoBehaviour
{
    
    void Start()
    {
        
    }
    public Animator a;

    void Update()
    {
        if (controller.set() == 1)
        {
            Debug.Log("1");
            a.SetTrigger("New Trigger");
        }
    }
}
