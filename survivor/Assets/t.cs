using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("Grounded", false);
        print("not on ground");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            anim.SetBool("Grounded", true);
            print("on ground");
        }
    }
}
