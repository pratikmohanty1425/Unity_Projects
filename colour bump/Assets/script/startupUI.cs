using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startupUI : MonoBehaviour
{

    //public GameObject startmenu;
    //public GameObject game;

    //public GameObject hits;

    public void Resume()
    {

        

        SceneManager.LoadScene(trigger.getsceneindex());
        //Time.timeScale = 1;
        //startmenu.SetActive(false);
        //game.SetActive(true);
        //hits.SetActive(true);

        //Debug.Log("resumed");

    }
    
    //void startmenuline()
    //{


    //    Time.timeScale = 0;
    //    startmenu.SetActive(true);

    //    hits.SetActive(false);
    //    game.SetActive(false);
        
    //    Debug.Log("startmenu");
    //}
    //void Start()
    //{
    //    startmenuline();
    //}


}
