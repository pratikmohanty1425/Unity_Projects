using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
    public static soundmanager instance;

    public AudioSource moveaudiosource, jumoaudiosource, powerupdieaudiosource, bgaudiosource;

    public AudioClip powerup, die, coin, gameover;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (gamemanager.instance.playsound)
        {
            bgaudiosource.Play();
        }
        else
        {
            bgaudiosource.Stop();
        }
    }
    
    public void playmovesound()
    {
        moveaudiosource.Play();
    }

    public void playjumpsound()
    {
        jumoaudiosource.Play();
    }

    public void playdiesound()
    {
        powerupdieaudiosource.clip = die;
        powerupdieaudiosource.Play();
    }

    public void playpowerupsound()
    {
        powerupdieaudiosource.clip = powerup;
        powerupdieaudiosource.Play();
    }

    public void playcoinsound()
    {
        powerupdieaudiosource.clip = coin;
        powerupdieaudiosource.Play();
    }

    public void playgameoversound()
    {
        bgaudiosource.Stop();
        bgaudiosource.clip = gameover;
        bgaudiosource.loop = false;
        bgaudiosource.Play();
    }
}
