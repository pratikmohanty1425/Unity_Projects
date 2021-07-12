using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisioncontroler : MonoBehaviour
{
    public ball ballmovment;
    public score s;

    void bounce(Collision2D c)
    {
        Vector3 ballposition = this.transform.position;
        Vector3 racketposition = c.gameObject.transform.position;

        float racket = c.collider.bounds.size.x;

        float y=0 ;
        if(c.gameObject.name=="player1")
        {
            y = 1;
        }
        else
        {
            y -= 1;
        }

        float x = (ballposition.x - racketposition.x) / racket;

        this.ballmovment.inc();
        this.ballmovment.moveball(new Vector2(x, y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player1" || collision.gameObject.name == "player2")
        {
            this.bounce(collision);
        }
        else if(collision.gameObject.name=="bottom")
        {
            Debug.Log("bottom hit");
            this.s.gp2();
            StartCoroutine(this.ballmovment.startball(false));
        }
        else if (collision.gameObject.name == "top")
        {
            ballmovment.movementspeed = 5;
            Debug.Log("top  hit");
            this.s.gp1();
            StartCoroutine(this.ballmovment.startball(true));
        }
    }
}
