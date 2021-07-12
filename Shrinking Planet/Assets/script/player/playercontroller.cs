using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public static playercontroller instance;

    public float movespeed = 40;
    public float rotationspeed = 100;
    private Vector3 rotationdirection;
    private Rigidbody mybody;
    public bool isplayerhit=false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        mybody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameManager.instance.isgameovermenuactive == false)
        {
            rotationmovement();
        }
    }

    private void FixedUpdate()
    {
        movement();
    }

    private void rotationmovement()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.Rotate(new Vector3(0, (Input.GetAxisRaw("Horizontal")), 0) * rotationspeed * Time.deltaTime);
        }
    }

    void movement()
    {
        mybody.MovePosition(mybody.position + transform.TransformDirection(new Vector3(0, 0, 1)) * movespeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "crator" && isplayerhit == false) 
        {
            isplayerhit = true;
            print("hit");
            GameManager.instance.gameover.SetActive(true);
            GameManager.instance.isgameovermenuactive=true;
        }
    }
}
