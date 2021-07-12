using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameplaymanager : MonoBehaviour
{
    public static gameplaymanager instance;

    [SerializeField]
    private Text countdown;

    public int countdowntimer = 60;

    [SerializeField]
    private Text score;

    private int scorecnt;

    [SerializeField]
    private Image scorefill;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    void Start()
    {
        displayscore(0);
        countdown.text = countdowntimer.ToString();
        StartCoroutine("countdowntimers");
    }

    IEnumerator countdowntimers()
    {
        yield return new WaitForSeconds(1);
        countdowntimer -= 1;

        countdown.text = countdowntimer.ToString();

        if(countdowntimer<=10)
        {
            soundmanager.instance.timerfx(true);
        }

        StartCoroutine("countdowntimers");

        if(countdowntimer<=0)
        {
            StopCoroutine("countdowntimers");
            soundmanager.instance.overfx();
            soundmanager.instance.timerfx(false);

            StartCoroutine("restart");
        }
    }

    public void displayscore(int scorevalue)
    {
        if(score == null)
        {
            return;
        }
        scorecnt += scorevalue;
        score.text = "$" + scorecnt;

        scorefill.fillAmount = (float)scorecnt / 100;

        if(scorecnt>=100)
        {
            player.instance.finishanim();
            StopCoroutine("countdowntimers");
            soundmanager.instance.overfx();

            StartCoroutine("restart");
        }
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }
}
