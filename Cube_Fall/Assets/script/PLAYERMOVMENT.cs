using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERMOVMENT : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        move();
    }
    
    void move()
    {
        if(Input.GetAxis("Horizontal")>0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }
    public float vel = 2.4f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag== "spikes")
        {
            Debug.Log("hit");
            Destroy(gameObject);
            Time.timeScale = Time.deltaTime;
        }
        if(collision.gameObject.tag == "speedright")
        {
            Debug.Log("hit");
            rb.velocity = new Vector2(vel*2, rb.velocity.y);
        }
        if (collision.gameObject.tag == "speedleft")
        {
            Debug.Log("hit");
            rb.velocity = new Vector2(-vel*2, rb.velocity.y);
        }
    }
    public void platformMove(float x)
    {
        rb.velocity = new Vector2(x, rb.velocity.y);
    }
}
