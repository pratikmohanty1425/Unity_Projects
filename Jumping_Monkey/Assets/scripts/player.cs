using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;

    public float movespeed = 2;

    public float normalpush = 10;
    public float extrapush = 15f;

    private bool initial;
    private bool died;

    private int count;

    public static player instance;

    private float minx=-1.84f, maxx= 1.86f;

    public AudioClip banana,bananas,death;
    private AudioSource AudioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        AudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move();
        check();
    }

    void check()
    {
        Vector2 temp = transform.position;
        if(temp.x<=minx)
        {
            temp.x = minx;
        }

        if(temp.x>=maxx)
        {
            temp.x = maxx;
        }

        transform.position = temp;
    }

    void move()
    {
        if(died)
        {
            
            return;
            
        }

        if(Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="extrapush")
        {
            AudioSource.clip = bananas;
            AudioSource.Play();
                rb.velocity = new Vector2(rb.velocity.x, extrapush);
                Destroy(collision.gameObject);
                return;
        }

        if(collision.gameObject.tag=="normalpush")
        {
            AudioSource.clip = banana;
            AudioSource.Play();
            rb.velocity = new Vector2(rb.velocity.x, normalpush);
                Destroy(collision.gameObject);
                return;
        }

        if (collision.gameObject.tag == "enemy")
        {
            if(cnt==0)
            {
                AudioSource.clip = death;
                AudioSource.Play();
            }
            cnt++;
            died = true;
            rb.velocity = new Vector2(rb.velocity.x + Random.Range(-4, 4), normalpush);
            rb.gravityScale = 5;
            Invoke("restart", 1f);
        }

    }
    int cnt = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "endpoint")
        {
            if (cnt == 0)
            {
                AudioSource.clip = death;
                AudioSource.Play();
            }
            cnt++;
            died = true;
            rb.velocity = new Vector2(rb.velocity.x + Random.Range(-2, 2), normalpush);

            Invoke("restart", 1f);
        }
    }

    void restart()
    {
        SceneManager.LoadScene(0);
    }
}
