using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float movementspeed;
    public float extraspeed;
    public float max;


    int cnt = 1;


    void Start()
    {
        StartCoroutine(this.startball());
    }

    public IEnumerator startball(bool isstartingplayer1 = true)
    {
        this.pos(isstartingplayer1);
        this.cnt = 0;
        yield return new WaitForSeconds(2);
        if(isstartingplayer1)
        {
            this.moveball(new Vector2(0, -1));

        }
        else
        {
            this.moveball(new Vector2(0, 1));
        }
    }

    public void moveball(Vector2 dir)
    {
        //inc();
        dir = dir.normalized;
        float speed = this.movementspeed + this.cnt * this.extraspeed;
        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = dir * speed;
    }
    
    public void inc()
    {
        if (this.cnt * this.extraspeed <= this.max)
        {
            this.cnt++;
        }
    }

    void pos(bool isstartingplayer1 = true)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if(isstartingplayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(3.5f, -1.32f, 227.881f);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(3.5f, 0, 227.881f);
        }
    }
}
