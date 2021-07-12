using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationevents : MonoBehaviour
{
    private Animator anim;

    private string walkanimation = "playerwalk";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void playerwalkanimation()
    {
        anim.Play(walkanimation);
        if (PlayerController.instance.playerjump)
        {
            PlayerController.instance.playerjump = false;
        }
    }

    public void animantionenabled()
    {
        gameObject.SetActive(false);
    }

    void pausepanelclose()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    
}
