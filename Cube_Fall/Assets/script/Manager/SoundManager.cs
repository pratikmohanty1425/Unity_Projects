using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource sound;

    [SerializeField]
    private AudioClip land, death, breaks, gameover, star;
        
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    
    public void landsound()
    {
        sound.clip = land;
        sound.Play();
    }
    public void deathsound()
    {
        sound.clip = death;
        sound.Play();
    }
    public void breaksound()
    {
        sound.clip = breaks;
        sound.Play();
    }
    public void gameoversound()
    {
        sound.clip = gameover;
        sound.Play();
    }
    public void starsound()
    {
        sound.clip = star;
        sound.Play();
    }
}
