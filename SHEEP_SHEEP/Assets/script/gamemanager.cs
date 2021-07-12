using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public Text score;

    public static gamemanager instance;

    int coins = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        score.text = coins.ToString();
    }

    public void increasescore()
    {
        coins++;
    }

    public void restart()
    {
        SceneManager.LoadScene("game");
    }
}
