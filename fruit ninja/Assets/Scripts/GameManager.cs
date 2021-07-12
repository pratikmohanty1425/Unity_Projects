using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [Header("start menu")]
    public GameObject g;

    [Header("Score Elements")]
    public int score;
    public int highscore;
    public Text scoreText;
    public Text highscoreText;


    [Header("GameOver")]
    public GameObject gameOverPanel;
    public Text gameOverPanelScoreText;
    public Text gameOverPanelHighScoreText;

    public AudioClip[] slice;
    AudioSource a;
    private void Awake()
    {
        gameOverPanel.SetActive(false);
        g.SetActive(true);
        a = GetComponent<AudioSource>();
        Time.timeScale = 0;
        GetHighscore();
    }

    private void GetHighscore(){

		highscore = PlayerPrefs.GetInt("Highscore");
		highscoreText.text = "Best: " + highscore;
    }


    public void IncreaseScore(int points){
        score += points;
        scoreText.text = score.ToString();

        if(score > highscore){
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = score.ToString();
        }

    }

    public void OnBombHit(){
        Time.timeScale = 0;

        gameOverPanelScoreText.text = "Score: " + score.ToString();
        gameOverPanelHighScoreText.text = "Best: " + highscore.ToString();
        gameOverPanel.SetActive(true);
        g.SetActive(false);

        Debug.Log("Bomb hit");
    }

    public void RestartGame(){

        score = 0;
        scoreText.text = score.ToString();

        gameOverPanel.SetActive(false);

        g.SetActive(false);
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable")){
            Destroy(g);
        }

        Time.timeScale = 1;
    }
    public void play()
    {

        g.SetActive(false);
        score = 0;
        scoreText.text = score.ToString();

        Time.timeScale = 1;
    }
    public void exit()
    {
        Application.Quit();
        Debug.Log("exit");
    }
    public void prs()
    {
        AudioClip rs = slice[Random.Range(0, slice.Length)];
        a.PlayOneShot(rs);
    }
}
