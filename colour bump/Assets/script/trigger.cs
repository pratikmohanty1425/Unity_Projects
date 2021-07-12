using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject lvlpanle =null;

    public int cnt = 1;
    public static int high;
    public static bool Reset;
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.name=="startline")
        {
            Debug.Log("start");
            GameManager.singleton.gamestarted = true;
        }
        if (gameObject.name == "lastline")
        {
            lvlpanle.SetActive(true);
            Debug.Log("game over");

            cnt++;
            if (cnt > getsceneindex())
            {
                PlayerPrefs.SetInt("sceneindex", cnt);
            }
            
        }
    }
    public static int getsceneindex()
    {
        int scene = PlayerPrefs.GetInt("sceneindex");
        return scene;
    }

    public void resets()
    {
        Debug.Log(getsceneindex().ToString());
        PlayerPrefs.SetInt("sceneindex", 2);
        Debug.Log(getsceneindex().ToString());
    }
    private void Start()
    {
        Debug.Log(cnt);
        Debug.Log(getsceneindex().ToString());
    }
}
