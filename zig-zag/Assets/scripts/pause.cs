using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public static bool gameispause = false;

    public GameObject pausemenu;
    public GameObject game;

    void Update()
    {
        
    }

    public void check()
    {
        if(gameispause)
        {
            Resume();
        }
        else
        {
            Pause();
        }
        
    }

    public void Resume()
    {
        pausemenu.SetActive(false);

        AnimationScript.isFloating = true;
        game.SetActive(true);
        Time.timeScale = 1;
        gameispause = false;
        Debug.Log("resumed");

    }
    void Pause()
    {
        pausemenu.SetActive(true);
        AnimationScript.isFloating = false;
        Time.timeScale = 0;
        gameispause = true;
        game.SetActive(false);
        Debug.Log("pasued");
    }
}
