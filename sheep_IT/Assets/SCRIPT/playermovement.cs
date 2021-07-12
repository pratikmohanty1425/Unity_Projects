using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playermovement : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 3;
    private float smoothmovingspeed = 15f;

    private Vector3 forward;

    private bool canmove;

    private Vector3 dpos;

    private Renderer Renderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        forward = transform.position;
        Renderer = GetComponent<Renderer>();
    }


    void Update()
    {
        updatefn();
        getinput();
    }

    private void FixedUpdate()
    {
        moveplayer();
    }

    void updatefn()
    {
        transform.forward = Vector3.Slerp
            (transform.forward, forward, Time.deltaTime * smoothmovingspeed);
    }

    void getinput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canmove = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            canmove = false;
        }
    }

    void moveplayer()
    {
        if (canmove)
        {
            //dpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //dpos.y = 0;
            dpos = new Vector3
                (Input.GetAxisRaw("Mouse X"), 0, Input.GetAxisRaw("Mouse Y"));
            dpos.Normalize();

            dpos *= speed * Time.deltaTime;
            dpos = Quaternion.Euler
                (0, Camera.main.transform.eulerAngles.y, 0) * dpos;

            rb.MovePosition(rb.position + dpos);

            if (dpos != Vector3.zero)
            {
                forward = Vector3.ProjectOnPlane(-dpos, Vector3.up);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rotate_button")
        {
            rotateplatform.instance.activerotate();
        }

        if(other.gameObject.tag=="red")
        {
            Renderer.material.color = Color.red;
        }

        if (other.gameObject.tag == "white")
        {
            Renderer.material.color = Color.white;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "rotate_button")
    //    {
    //        rotateplatform.instance.activerotate();
    //    }
    //}
}
