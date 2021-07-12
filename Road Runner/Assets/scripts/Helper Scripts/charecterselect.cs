using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charecterselect : MonoBehaviour
{
    public GameObject[] availableheroes;

    private int currentindex;

    public Text selectedtext;
    public GameObject staricon;
    public Image selectbtn;
    public Sprite buttongreen, buttonblue;

    private bool[] heros;

    public Text starscore;

    void Start()
    {
        initializecharacters();
    }

    void initializecharacters()
    {
        currentindex = gamemanager.instance.selectedIndex;
        for (int i = 0; i < availableheroes.Length; i++) 
        {
            availableheroes[i].SetActive(false);
        }
        availableheroes[currentindex].SetActive(true);

        heros = gamemanager.instance.heroes;

    }

    public void nextchar()
    {
        availableheroes[currentindex].SetActive(false);

        if (currentindex + 1 == availableheroes.Length) 
        {
            currentindex = 0;
        }
        else
        {
            currentindex++;
        }
        availableheroes[currentindex].SetActive(true);
        checkifcharisunlocked();
    }

    public void previouschar()
    {
        availableheroes[currentindex].SetActive(false);

        if (currentindex - 1 == -1)
        {
            currentindex = availableheroes.Length-1;
        }
        else
        {
            currentindex--;
        }
        availableheroes[currentindex].SetActive(true);
        checkifcharisunlocked();
    }

    void checkifcharisunlocked()
    {
        if (heros[currentindex])//hero is unlocked 
        {
            staricon.SetActive(false);
            if (currentindex == gamemanager.instance.selectedIndex)
            {
                selectbtn.sprite = buttongreen;
                selectedtext.text = "Selected";
            }
            else
            {
                selectbtn.sprite = buttonblue;
                selectedtext.text = "Select?";
            }
        }
        else//hero is locked
        {
            selectbtn.sprite = buttonblue;
            staricon.SetActive(true);
            selectedtext.text = "1000";
        }
    }

    public void selectchar()
    {
        if (!heros[currentindex])//if the hero is no unlocked
        {
            if (currentindex != gamemanager.instance.selectedIndex)
            {
                if (gamemanager.instance.StarScore >= 1000)//unlock hero if u have enough stars
                {
                    gamemanager.instance.StarScore -= 1000;
                    selectbtn.sprite = buttongreen;
                    staricon.SetActive(false);
                    selectedtext.text = "Selected";
                    heros[currentindex] = true;
                    starscore.text = gamemanager.instance.StarScore.ToString();

                    gamemanager.instance.selectedIndex = currentindex;
                    gamemanager.instance.heroes = heros;
                    gamemanager.instance.savegamedata();
                }
            }
            else
            {
                print("NOT ENOUGH STARS");
            }
            
        }
        else//
        {
            selectbtn.sprite = buttongreen;
            selectedtext.text = "Selected";
            gamemanager.instance.selectedIndex = currentindex;
            gamemanager.instance.savegamedata();
        }
    }
}
