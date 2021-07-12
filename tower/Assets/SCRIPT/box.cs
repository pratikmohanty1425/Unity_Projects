using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{

    private float max = -2.04f, min = 2.04f;

    private bool canmove;
    float speed = 3;



    private Rigidbody rb;

    private bool gameover;
    private bool ignorecollision;
    private bool ignoretrigger;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    void Start()
    {
        canmove = true;
        if (Random.Range(0,2)>0)
        {
            speed *= -1;
        }
        gamecontroller.instance.b = this;
    }


    void Update()
    {
        move();
        if (Input.GetMouseButtonDown(0))
        {
            drop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (ignorecollision)
            return;
        if(collision.gameObject.tag=="floor")
        {
            Invoke("land", 2);
            ignorecollision = true;
        }
        if (collision.gameObject.tag == "box1")
        {
            Invoke("land", 2);
            ignorecollision = true;
        }
        if (collision.gameObject.tag=="end")
        {
            restart();
            Debug.Log("hit");
            gameover = true;
            CancelInvoke("land");
        }
    }


    public void drop()
    {
        canmove = false;
        rb.useGravity=true;

    }
    void land()
    {
        if(gameover)
        {
            return;
        }
        else
        {
            ignorecollision = true;
            ignoretrigger = true;
            gamecontroller.instance.spbox();
            gamecontroller.instance.movecam();


        }
    }
    void move()
    {
        if(canmove)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            if (temp.x < max)
            {
                speed *= -1;
            }
            if (temp.x > min)
            {
                speed *= -1;
            }
            transform.position = temp;
        }
    }
    public void restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
