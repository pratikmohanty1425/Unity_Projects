using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchscreen : MonoBehaviour
{
    int cnt;
    public void ping()
    {
        
        Switch();
    }

    public GameObject g;
    private bool walking = true;
    
    public void Switch()
    {
        walking = !walking;
        if (walking)
        {
            g.transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            g.transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }
}
