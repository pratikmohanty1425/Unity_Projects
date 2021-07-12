using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int sceneindextorestart;

    public static GameManager singleton;
    public bool gamestarted { get; set; }
    public bool gameended { get; set; }
    [SerializeField] private float slowmotion=.2f;


    private void Awake()
    {
        if(singleton==null)
        {
            singleton = this;
        }
        else if(singleton!=this)
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }
    public void startgame()
    {
        gamestarted = true;
        Debug.Log("started");
    }
    public void gameend(bool win)
    {
        gameended = true;
        Debug.Log("ended");
        
        if(!win)
        {

            Time.timeScale = slowmotion;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            Invoke("restart", 1);
        }
        
    }
    void restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneindextorestart);
    }
    
}
