using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeranimation : MonoBehaviour
{
    private Animator anim;
    public static playeranimation instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        anim=GetComponent<Animator>();
    }

    public void walk(bool move)
    {
        anim.SetBool(Animationtags.movementbool, move);
    }

    public void punch1()
    {
        anim.SetTrigger(Animationtags.punch1trigger);
    }

    public void punch2()
    {
        anim.SetTrigger(Animationtags.punch2trigger);
    }

    public void punch3()
    {
        anim.SetTrigger(Animationtags.punch3trigger);
    }

    public void kick1()
    {
        anim.SetTrigger(Animationtags.kick1trigger);
    }

    public void kick2()
    {
        anim.SetTrigger(Animationtags.kick2trigger);
    }

    public void enemyattack(int attack)
    {
        if (attack == 0)
        {
            anim.SetTrigger(Animationtags.attack1trigger);
        }
        if (attack == 1)
        {
            anim.SetTrigger(Animationtags.attack2trigger);
        }
        if (attack == 2)
        {
            anim.SetTrigger(Animationtags.attack3trigger);
        }
    }

    public void playidle()
    {
        anim.Play(Animationtags.idleanimation);
    }

    public void knockdown()
    {
        anim.SetTrigger(Animationtags.knockdownanimation);
    }

    public void standup()
    {
        anim.SetTrigger(Animationtags.standupanimation);
    }

    public void hit()
    {
        anim.SetTrigger(Animationtags.hittrigger);
    }

    public void death()
    {
        anim.SetTrigger(Animationtags.death);
    }
}
