using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Animator anim;

    public static player instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }

        anim = GetComponent<Animator>();
    }

    public void idealanim()
    {
        anim.Play(Animationtags.idealanim);
    }

    public void ropeanim()
    {
        anim.Play(Animationtags.ropewrapanim);
    }

    public void finishanim()
    {
        anim.Play(Animationtags.chearanim);
    }
}
