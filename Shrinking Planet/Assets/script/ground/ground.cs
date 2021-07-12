using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    private float time=0;
    private float radius = 100;
    private float shrinkspeed=1;
    void Start()
    {
        
    }

    void Update()
    {
        shrink();
    }

    void shrink()
    {
        
        if(GameManager.instance.sc>10)
        {
            time = Time.deltaTime;
            shrinkspeed += time;
            radius -= time * 0.2f;
            transform.localScale = new Vector3(radius, radius, radius);
        }
        
    }
}
