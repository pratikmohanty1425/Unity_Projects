using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmenucontroller : MonoBehaviour
{
    public GameObject heromenu;
    public Text startscoretext;

    public Image music_img;
    public Sprite musicoff, musicon;

    public void playgame()
    {
        SceneManager.LoadScene("gameplay");
    }

    public void hero_menu()
    {
        heromenu.SetActive(true);
        startscoretext.text = "" + gamemanager.instance.StarScore;

    }

    public void homemenu()
    {
        heromenu.SetActive(false);
    }

    public void music()
    {
        if(gamemanager.instance.playsound)
        {
            music_img.sprite = musicoff;
            gamemanager.instance.playsound = false;
        }
        else
        {
            music_img.sprite = musicon;
            gamemanager.instance.playsound = true;
        }
    }
}

