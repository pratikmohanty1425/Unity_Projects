using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class playermovment : MonoBehaviour
{
    private Rigidbody rb;

    private float moveforce = 0.5f, jumpforce = 0.15f;
    private float jumptime = 0.15f;

    public static playermovment instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        getinput();
        gettouchinput();
    }

    void gettouchinput()
    {
        if (Input.touchCount == 1)
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                Jump(true);
            }
            else if (touch.position.x > Screen.width / 2)
            {
                Jump(false);
            }
        }

    }

    void getinput()
    {
        //if (Input.touchCount > 0)
        //{
        //    var touch = Input.GetTouch(0);
        //    if (touch.position.x < Screen.width / 2)
        //    {
        //        Jump(true);
        //    }
        //    else if (touch.position.x > Screen.width / 2)
        //    {
        //        Jump(false);
        //    }
        //}
        //else
        //{
            

        //}
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Jump(true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Jump(false);
        }
    }

    void Jump(bool left)
    {
        soundmanager.instance.jumps();

        if(left)
        {
            transform.DORotate(new Vector3(0, 90, 0), 0);
            rb.DOJump(new Vector3(transform.position.x - moveforce,
                transform.position.y + jumpforce, transform.position.z), 0.5f, 1, jumptime);

        }
        else
        {
            transform.DORotate(new Vector3(0, -180, 0), 0);
            rb.DOJump(new Vector3(transform.position.x ,
                transform.position.y + jumpforce, transform.position.z + moveforce), 0.5f, 1, jumptime);

        }
    }

    
}
