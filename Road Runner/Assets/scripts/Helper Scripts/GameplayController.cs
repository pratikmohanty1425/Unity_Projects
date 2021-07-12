using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    public float movespeed, distancefactor = 1;
    private float distancemove;
    private bool gamejuststarted;

    public GameObject obstacles_obj;
    public GameObject[] obstacleslist;

    [HideInInspector]
    public bool obstaclesidalive;

    private string coroutine_name = "spawnobstacles";

    private Text scoretext, starscoretext;

    private int starscorecount, scorecount;

    public GameObject pausepanel;

    public Animator pauseanim;

    public GameObject gameoverpanel;
    public Animator gameoveranim;

    public Text finalscoretext, bestscoretext, finalstarscoretext;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }

        scoretext = GameObject.Find("scoretext").GetComponent<Text>();
        starscoretext = GameObject.Find("startext").GetComponent<Text>();
    }

    private void Start()
    {
        gamejuststarted = true;
        getobstacles();
        StartCoroutine(spawnobstacles());
    }

    void Update()
    {
        movecamera();
    }

    void movecamera()
    {
        if(gamejuststarted)
        {
            if(!PlayerController.instance.playerdied)
            {
                if (movespeed < 12)
                {
                    movespeed += Time.deltaTime * 0.5f;
                }
                else
                {
                    movespeed = 12;
                    gamejuststarted = false;
                }
            }
        }

        if (!PlayerController.instance.playerdied)
        {
            Camera.main.transform.position += new Vector3(movespeed * Time.deltaTime,
            0, 0);
            updatedistance();
        }
            
    }

    void updatedistance()
    {
        distancemove += Time.deltaTime * distancefactor;
        float round = Mathf.Round(distancemove);

        scorecount = (int)round;
        scoretext.text=round.ToString();

        if(round>=30 && round<60)
        {
            movespeed = 14;
        }
        else if(round>=60)
        {
            movespeed = 16;
        }
    }

    void getobstacles()
    {
        obstacleslist = new GameObject[obstacles_obj.transform.childCount];

        for(int i=0;i<obstacleslist.Length;i++)
        {
            obstacleslist[i] = obstacles_obj.GetComponentsInChildren<obstaclesholder>(true)[i].gameObject;
        }
    }

    IEnumerator spawnobstacles()
    {
        while(true)
        {
            if(!PlayerController.instance.playerdied)
            {
                if(!obstaclesidalive)
                {
                    if (Random.value <= 0.85f)
                    {
                        int randomindex = 0;
                        do
                        {
                            randomindex = Random.Range(0, obstacleslist.Length);
                        }
                        while (obstacleslist[randomindex].activeInHierarchy);
                        obstacleslist[randomindex].SetActive(true);
                        obstaclesidalive = true;

                    }
                }
            }
            yield return new WaitForSeconds(0.6f);
        }
    }

    public void updatestarscore()
    {
        starscorecount++;
        starscoretext.text = starscorecount.ToString();
    }

    public void pausegame()
    {
        Time.timeScale = 0;
        pausepanel.SetActive(true);
        pauseanim.Play("slidein");
    }

    public void gameover()
    {
        Time.timeScale = 0;
        gameoverpanel.SetActive(true);
        gameoveranim.Play("slidein");
        finalscoretext.text = scorecount.ToString();
        finalstarscoretext.text = starscorecount.ToString();
        if (gamemanager.instance.scoreCount < scorecount)
        {
            gamemanager.instance.scoreCount = scorecount;
        }
        bestscoretext.text = gamemanager.instance.scoreCount.ToString();
        gamemanager.instance.StarScore += starscorecount;
        gamemanager.instance.savegamedata();
    }

    public void Resumegame()
    {
        pauseanim.Play("slideout");
    }

    public void restartgame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("gameplay");
    }

    public void homebutton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainmenu");
    }
}
