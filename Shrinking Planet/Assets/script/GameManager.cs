using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoretext;
    public Text finalscoretext;
    [HideInInspector]
    public float sc;

    public GameObject mainmenu;
    public GameObject scoreui;
    public GameObject gameover;

    public GameObject player;

    private GameObject[] enemy;
    private GameObject[] crater;



    public bool ismenuactive;
    public bool ispausemenuactive;
    public bool isgameovermenuactive;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        sc = 0;
        mainmenu.SetActive(true);
        scoreui.SetActive(false);
        gameover.SetActive(false);
        player.SetActive(false);
        ismenuactive = true;
    }

    void Update()
    {
        if (ismenuactive==false && isgameovermenuactive==false)
        {
            score();
        }
        if (isgameovermenuactive)
        {
            finalscoretext.text = sc.ToString("0.0") + "m";
        }
    }

    void score()
    {
        sc += Time.deltaTime; 
        scoretext.text = sc.ToString("0.0")+"m";
    }

    public void play()
    {
        ismenuactive = false;
        mainmenu.SetActive(false);
        scoreui.SetActive(true);
        player.SetActive(true);
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject des in enemy)
        {
            Destroy(des);
        }
        crater = GameObject.FindGameObjectsWithTag("crator");
        foreach (GameObject des in crater)
        {
            Destroy(des);
        }

    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        Application.Quit();
    }
}
