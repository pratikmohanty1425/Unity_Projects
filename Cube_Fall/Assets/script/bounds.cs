using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounds : MonoBehaviour
{
    public float minx = -2.67f, maxx = 2.67f, miny = -6;
    private bool out_of_bounce;

    void Update()
    {
        checkbounce();
    }

    void checkbounce()
    {
        Vector2 temp = transform.position;
        if(temp.x>=maxx)
        {
            temp.x = maxx;
        }
        if(temp.x<minx)
        {
            temp.x = minx;
        }

        transform.position = temp;

        if(temp.y<=miny)
        {
            if(!out_of_bounce)
            {
                out_of_bounce = true;
                SoundManager.instance.deathsound();
                GameManager.instance.restart();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.)
    }
}
