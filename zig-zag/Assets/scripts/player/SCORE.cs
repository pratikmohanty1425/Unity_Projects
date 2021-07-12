using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class SCORE : MonoBehaviour
{
    public int cnt;
    public Text t;
    public Text high;
    public static int inc = 1;

    private void Awake()
    {
        high.text = gethighscore().ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "point")
        {
            cnt++;
            inc = cnt;
            t.text = cnt.ToString();
            if (cnt > gethighscore())
            {
                PlayerPrefs.SetInt("Highscore", cnt);
                high.text = cnt.ToString();
            }
            Destroy(other.gameObject);
        }

    }

    public int gethighscore()
    {
        int mynum = PlayerPrefs.GetInt("Highscore");
        return mynum;
    }

}
