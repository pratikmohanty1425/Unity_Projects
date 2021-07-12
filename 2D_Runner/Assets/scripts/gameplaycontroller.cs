using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameplaycontroller : MonoBehaviour
{
    public GameObject bg1;
    public GameObject bg2;
    public GameObject enemy;
    private GameObject[] enemies;

    Rigidbody2D mybody1, mybody2, phyenemy;

    public float speed = -3f;

    float bglength = 0;
    float obstaclechangetime = 0;
    public int no_of_ennemy = 5;
    int cnt = 0;
    bool pause = false;

    int ran = 0;
    void Start()
    {
        mybody1 = bg1.GetComponent<Rigidbody2D>();
        mybody2 = bg2.GetComponent<Rigidbody2D>();
        enemies = new GameObject[no_of_ennemy];

        bglength = bg1.GetComponent<BoxCollider2D>().size.x;
        bgmotion(speed);

        for(int i=0;i<enemies.Length;i++)
        {
            enemies[i] = Instantiate(enemy, new Vector3(-20f, -20f), Quaternion.identity);
            phyenemy = enemies[i].AddComponent<Rigidbody2D>();
            phyenemy.gravityScale = 0;
            phyenemy.velocity = new Vector2(speed, 0);
        }

    }


    void Update()
    {
        if (bg1.transform.position.x <= -bglength) 
        {
            bg1.transform.position += new Vector3(bglength * 2, 0);
        }

        if (bg2.transform.position.x <= -bglength)
        {
            bg2.transform.position += new Vector3(bglength * 2, 0);
        }

        obstaclechangetime += Time.deltaTime;

        float obemergancetime = 4;

        if (obstaclechangetime > obemergancetime) 
        {
            obstaclechangetime = 0;
            enemies[cnt].transform.position = new Vector3(10, -3.4f);
            cnt++;
            if(cnt>=enemies.Length)
            {
                cnt = 0;
            }
        }
    }

    public void gameover()
    {
        for (int i = 0; i < enemies.Length; i++) 
        {
            enemies[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            bgmotion(0);
        }
    }

    void bgmotion(float speeds)
    {
        mybody1.velocity = new Vector2(speeds, 0);
        mybody2.velocity = new Vector2(speeds, 0);
    }

    public void pauses()
    {
        
        pause = !pause;
        Debug.Log(pause);
        paused();
    }
    void paused()
    {
        if(!pause)
        {
            Time.timeScale = 0;
            pause = true;
        }
        else if(pause)
        {
            Time.timeScale = 1;
            pause = false;
        }
    }
}
