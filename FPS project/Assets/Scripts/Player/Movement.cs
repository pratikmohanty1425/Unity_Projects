using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    private Animator anim;

    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float x;
        float z;
        bool jumpPressed = false;
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        walkforward(z);
        jumpPressed = Input.GetButtonDown("Jump");
        jumpanim(jumpPressed);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (jumpPressed && isGrounded)
        {
            StartCoroutine(jumptimer());
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void walkforward(float z)
    {
        if (z>0||z<0)
        {
            anim.SetTrigger("walk");
        }

        if (z == 0)
        {
            anim.SetTrigger("idle");
        }
    }

    void jumpanim(bool jump)
    {
        if (jump)
        {
            anim.SetTrigger("jump");
            StartCoroutine(idlejumptimer());
        }
    }

    IEnumerator idlejumptimer()
    {
        yield return new WaitForSeconds(2);
        anim.SetTrigger("idle");
    }

    IEnumerator jumptimer()
    {
        yield return new WaitForSeconds(0.5f);
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
