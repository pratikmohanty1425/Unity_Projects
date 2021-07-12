using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float move_speed = 2f;
    public float bound_y=6;

    public bool movingpleft, movingpright, isbreakable, isplatform, isstar, isenemy;
    private Animator anim;
    private Collider2D col;

    int score = 0;
    private void Awake()
    {
        if(isbreakable)
        {
            anim = GetComponent<Animator>();
            col = GetComponent<Collider2D>();
        }
    }

    void Update()
    {
        move();
        
    }

    void move()
    {
        Vector2 tmp = transform.position;
        tmp.y += move_speed * Time.deltaTime;
        transform.position = tmp;

        if(tmp.y>=bound_y)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (isbreakable)
            {
                Debug.Log("break");
                anim.SetBool("breaks", true);
                Invoke("breaks", 0.5f);
            }

            if(isplatform)
            {
                SoundManager.instance.landsound();
            }
        }
        
    }

    void breaks()
    {
        SoundManager.instance.breaksound();
        col.enabled = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if(movingpleft)
            {
                collision.gameObject.GetComponent<PLAYERMOVMENT>().platformMove(-1.5f);
            }

            if (movingpright)
            {
                collision.gameObject.GetComponent<PLAYERMOVMENT>().platformMove(1.5f);
            }

            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (isstar)
            {
                SoundManager.instance.starsound();
                GameManager.instance.scores();
                Invoke("destroyobj", 0.5f);
            }
            if (isenemy)
            {
                SoundManager.instance.starsound();
                GameManager.instance.scores();
                Invoke("destroyobj", 0.8f);
            }

        }
    }

    void destroyobj()
    {
        Destroy(gameObject);
    }
}
