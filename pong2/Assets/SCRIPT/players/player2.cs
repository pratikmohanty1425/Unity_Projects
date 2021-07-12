using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    public float movementspeed;
    public GameObject ball;
    private void FixedUpdate()
    {

        if((Mathf.Abs(transform.position.x - ball.transform.position.x)>0.5f))
        {
            if(transform.position.x < ball.transform.position.x)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(Time.deltaTime, 0) * movementspeed;
            }
            else 
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-Time.deltaTime, 0) * movementspeed ;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
