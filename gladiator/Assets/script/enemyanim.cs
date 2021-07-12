using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyanim : MonoBehaviour
{
    private Animator anim;
    public static enemyanim instance;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        if (instance == null)
        {
            instance = this;
        }
    }

    public void walk(bool walk)
    {
        anim.SetBool("walk2", walk);
    }

    public void defend(bool defend)
    {
        anim.SetBool("defend2", defend);
    }

    public void attack(int n)
    {
        if (n == 1)
        {
            anim.SetTrigger("attack12");
        }
        else if (n == 2)
        {
            anim.SetTrigger("attack22");
        }
        else if (n == 3)
        {
            anim.SetTrigger("attack32");
        }
        else
        {
            anim.SetTrigger("attack12");
        }

    }

    void freezanim()
    {
        anim.speed = 0;
    }

    public void unfreezanim()
    {
        anim.speed = 1;
    }
}
