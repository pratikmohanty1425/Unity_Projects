using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
   public Transform canvas;
   public Slider sliderPlayerHealth;
   public  Text textPlayerName;
   public Character player;
   public  GameObject framesMenu;

    public virtual void Awake()
    {
        framesMenu.SetActive(false);
    }

    void Start()
    {
        textPlayerName.text = player.characterName;
    }

    void Update()
    {
        sliderPlayerHealth.maxValue = player.maxHealth;
        sliderPlayerHealth.value = player.health;
        CheckCancel();
    }

    void CheckCancel()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (framesMenu.activeInHierarchy)
            {
                framesMenu.SetActive(false);
            }
            else
            {
                framesMenu.SetActive(true);
            }
        }
    }

    public void ClickReturn()
    {
        framesMenu.SetActive(false);
    }

    public void ClickQuit()
    {
        SceneManager.LoadScene("Menu");
    }
}
