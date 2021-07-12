using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
    public static soundmanager instance;

    [SerializeField]
    private AudioSource gamestart, gameend, coinsound, jump;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    public void gamestarts()
    {
        gamestart.Play();
    }

    public void gameends()
    {
        gameend.Play();
    }

    public void coinsounds()
    {
        coinsound.Play();
    }

    public void jumps()
    {
        jump.Play();
    }
}
