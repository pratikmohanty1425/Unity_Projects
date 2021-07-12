using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    public float movementspeed;

    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity
            = new Vector2(v, 0) * movementspeed;

    }

    
}
