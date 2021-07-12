using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinteraction : MonoBehaviour
{
    private Rigidbody rb;
    private bool playerdie;
    private followcam cam;


    private void Awake()
    {
        
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.GetComponent<followcam>();
    }

    private void Update()
    {
        if(!playerdie)
        {
            if(rb.velocity.sqrMagnitude>60)
            {
                playerdie = true;
                cam.canfollow = false;
                soundmanager.instance.gameends();
                gamemanager.instance.Invoke("restart", 1f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spike")
        {
            cam.canfollow = false;
            Destroy(gameObject);
            soundmanager.instance.gameends();
            gamemanager.instance.Invoke("restart",1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            gamemanager.instance.increasescore();
            Destroy(collision.gameObject, 2);
            soundmanager.instance.coinsounds();
        }

        if(collision.gameObject.tag == "endplatform")
        {
            soundmanager.instance.gamestarts();
            gamemanager.instance.Invoke("restart", 1f);
        }

        if (collision.gameObject.tag == "ground")
        {
            //Destroy(collision.gameObject,5);
        }
    }
}
