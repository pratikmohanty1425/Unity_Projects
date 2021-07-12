using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovment : MonoBehaviour
{
    private playeranimation anim;

    private Rigidbody mybody;

    public float walkspeed = 3;
    public float zspeed = 1.5f;

    private float yrotation = -90,yrotationv=-180;

    private float rotationspeed = 15;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<playeranimation>();
    }

    private void Update()
    {
        rotateplayer();
    }

    void FixedUpdate()
    {
        movement();
    }

    void movement()
    {
        mybody.velocity = new Vector3(Input.GetAxisRaw(Axis.Horizontalaxis) * (-walkspeed), mybody.velocity.y, Input.GetAxisRaw(Axis.Verticalaxis) * (-zspeed));
        playerwalk();
    }

    void rotateplayer()
    {
        if (Input.GetAxisRaw(Axis.Horizontalaxis) > 0)
        {
            transform.rotation = Quaternion.Euler(0, yrotation, 0);
        }
        else if(Input.GetAxisRaw(Axis.Horizontalaxis) < 0)
        {
            transform.rotation = Quaternion.Euler(0, Mathf.Abs(yrotation), 0);
        }

        if(Input.GetAxisRaw(Axis.Verticalaxis) > 0)
        {
            transform.rotation = Quaternion.Euler(0, yrotationv, 0);
        }
        else if (Input.GetAxisRaw(Axis.Verticalaxis) < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if(Input.GetAxisRaw(Axis.Verticalaxis) > 0 && Input.GetAxisRaw(Axis.Horizontalaxis) > 0)
        {
            transform.rotation = Quaternion.Euler(0, -135, 0);
        }
        if (Input.GetAxisRaw(Axis.Verticalaxis) < 0 && Input.GetAxisRaw(Axis.Horizontalaxis) > 0)
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
        if (Input.GetAxisRaw(Axis.Verticalaxis) > 0 && Input.GetAxisRaw(Axis.Horizontalaxis) < 0)
        {
            transform.rotation = Quaternion.Euler(0, 135, 0);
        }
        if (Input.GetAxisRaw(Axis.Verticalaxis) < 0 && Input.GetAxisRaw(Axis.Horizontalaxis) < 0)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }

    }

    void playerwalk()
    {
        if (mybody.velocity!=Vector3.zero)
        {
            anim.walk(true);
        }
        else
        {
            anim.walk(false);
        }
    }

    
}
