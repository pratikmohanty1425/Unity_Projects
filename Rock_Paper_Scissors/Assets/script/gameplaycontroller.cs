using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum gamechoises
{
    NONE,
    Rock,
    Paper,
    Scissors
}
public class gameplaycontroller : MonoBehaviour
{
    [Header("sprites")]
    public Sprite rock;
    public Sprite paper;
    public Sprite scissors;

    [Header("images")]
    public Image playerch;
    public Image opsch;

    [Header("text")]
    [SerializeField]
    private Text info;

    private gamechoises player_ch = gamechoises.NONE, ops_ch = gamechoises.NONE;
    private animcontroller anim;

    private void Awake()
    {
        anim = GetComponent<animcontroller>();
    }

    public void setchoise(gamechoises gameChoise) 
    {
        Debug.Log(gameChoise);
        switch(gameChoise)
        {

            case gamechoises.Rock:
                player_ch = gamechoises.Rock;
                playerch.sprite = rock;
                Debug.Log(gamechoises.Rock);
                break;
            case gamechoises.Paper:
                player_ch = gamechoises.Paper;
                playerch.sprite = paper;
                break;
            case gamechoises.Scissors:
                player_ch = gamechoises.Scissors;
                playerch.sprite = scissors;
                break;
        }
        setopschoise();
        determinewinner();
    }
    private void setopschoise()
    {
        int ran = Random.Range(0, 3);
        switch (ran)
        {
            case 0:
                ops_ch = gamechoises.Rock;
                opsch.sprite = rock;
                break;
            case 1:
                ops_ch = gamechoises.Paper;
                opsch.sprite = paper;
                break;
            case 2:
                ops_ch = gamechoises.Scissors;
                opsch.sprite = scissors;
                break;
        }
    }
    
    private void determinewinner()
    {
        if(ops_ch == player_ch )
        {
            info.text = "DRAW";
            StartCoroutine(displaywinner());
            return;
        }
        if (player_ch == gamechoises.Paper && ops_ch == gamechoises.Rock)
        {
            info.text = "YOU WIN";
            StartCoroutine(displaywinner());
            return;
        }
        
        if (player_ch == gamechoises.Rock && ops_ch == gamechoises.Scissors)
        {
            info.text = "YOU WIN";
            StartCoroutine(displaywinner());
            return;
        }
        if (player_ch == gamechoises.Scissors && ops_ch == gamechoises.Paper)
        {
            info.text = "YOU WIN";
            StartCoroutine(displaywinner());
            return;
        }
        //////////////////////////////////////////////////////////////////////
        if (ops_ch == gamechoises.Paper && player_ch == gamechoises.Rock)
        {
            info.text = "OPPONENT WIN";
            StartCoroutine(displaywinner());
            return;
        }

        if (ops_ch == gamechoises.Rock && player_ch == gamechoises.Scissors)
        {
            info.text = "OPPONENT WIN";
            StartCoroutine(displaywinner());
            return;
        }
        if (ops_ch == gamechoises.Scissors && player_ch == gamechoises.Paper)
        {
            info.text = "OPPONENT WIN";
            StartCoroutine(displaywinner());
            return;
        }
    }

    IEnumerator displaywinner()
    {
        yield return new WaitForSeconds(2);
        info.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        info.gameObject.SetActive(false);
        anim.resteanim();
    }
}
