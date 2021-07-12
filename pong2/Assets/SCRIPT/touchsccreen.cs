using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class touchsccreen : MonoBehaviour
{
    public Rigidbody2D rb;
    public float dirx;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        dirx = CrossPlatformInputManager.GetAxis("Horizontal") * speed *Time.deltaTime;
        rb.velocity = new Vector2(dirx, 0f);
        if (Input.GetAxis("Horizontal")!=0)
        {
            dirx = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(dirx, 0f) * speed * Time.deltaTime;
        }

    }
}
