using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour
{
    private Animator anim;
    public static animations instance;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        if(instance==null)
        {
            instance = this;
        }
    }

    public void walk(bool walk)
    {
        anim.SetBool("walk", walk);
    }

    public void defend(bool defend)
    {
        anim.SetBool("defend", defend);
    }

    public void attack(int n)
    {
        if(n==1)
        {
            anim.SetTrigger("attack1");
        }
        else if (n == 2)
        {
            anim.SetTrigger("attack2");
        }
        else if (n == 3)
        {
            anim.SetTrigger("attack3");
        }
        else
        {
            anim.SetTrigger("attack1");
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
