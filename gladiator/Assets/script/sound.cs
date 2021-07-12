using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    private AudioSource soundfx;
    [SerializeField]
    private AudioClip attack1, attack2, attack3, die1;

    public static sound instance;

    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }
        soundfx = GetComponent<AudioSource>();
    }

    public void at1()
    {
        soundfx.clip = attack1;
        soundfx.Play();
    }
    public void at2()
    {
        soundfx.clip = attack2;
        soundfx.Play();
    }
    public void at3()
    {
        soundfx.clip = attack3;
        soundfx.Play();
    }
    public void die()
    {
        soundfx.clip = die1;
        soundfx.Play();
    }
}
