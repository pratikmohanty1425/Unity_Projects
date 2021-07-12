using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundbehavior : MonoBehaviour
{
    public AudioSource music;
    private void Start()
    {
        music.Play();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(music)
            {
                if(music.isPlaying)
                {

                    music.Pause();
                }
                else
                {

                    music.Play();
                }

            }
        }
    }

    public void onoff()
    {
        if (music.isPlaying)
        {

            music.Pause();
        }
        else
        {

            music.Play();
        }
    }
}
