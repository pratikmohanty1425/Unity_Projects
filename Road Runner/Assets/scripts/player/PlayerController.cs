using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private Animator anim;

    private string jumpanimation = "playerjump", changelineanimation = "changeline";

    public GameObject player, shadow;

    public Vector3 firstposofplayer, secondposofplayer;

    [HideInInspector]
    public bool playerdied;

    [HideInInspector]
    public bool playerjump;

    public GameObject explosion;

    private SpriteRenderer playerrenderer;

    public Sprite trexsprite, playersprite;

    private bool trextrigger;

    private GameObject[] stareffects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        anim = player.GetComponent<Animator>();

        playerrenderer = player.GetComponent<SpriteRenderer>();

        stareffects = GameObject.FindGameObjectsWithTag(mytags.stareffect);
    }

    void Start()
    {
        string path = "Sprites/Player/hero" + gamemanager.instance.selectedIndex + "_big";
        playersprite = Resources.Load<Sprite>(path);
        playerrenderer.sprite = playersprite;
    }

    // Update is called once per frame
    void Update()
    {
        handlechangeline();
        handlejump();
    }

    void handlechangeline()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W))
        {
            anim.Play(changelineanimation);
            transform.localPosition = secondposofplayer;
            soundmanager.instance.playmovesound();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            anim.Play(changelineanimation);
            transform.localPosition = firstposofplayer;
            soundmanager.instance.playmovesound();
        }
    }

    void handlejump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!playerjump)
            {
                anim.Play(jumpanimation);
                playerjump = true;
                soundmanager.instance.playjumpsound();
            }
        }
    }

    void die()
    {
        playerdied = true;
        player.SetActive(false);
        shadow.SetActive(false);
        soundmanager.instance.playdiesound();
        soundmanager.instance.playgameoversound();
        GameplayController.instance.gameover();
        GameplayController.instance.movespeed = 0;

    }

    void diewithobstacles(Collider2D target)
    {
        die();
        explosion.transform.position = target.transform.position;
        explosion.SetActive(true);
        target.gameObject.SetActive(false);

        soundmanager.instance.playdiesound();

    }

    IEnumerator terxduration()
    {
        yield return new WaitForSeconds(7);
        if(trextrigger)
        {
            trextrigger = false;
            playerrenderer.sprite = playersprite;
        }
    }

    void destroyobstacles(Collider2D target)
    {
        explosion.transform.position = target.transform.position;
        explosion.SetActive(false);
        explosion.SetActive(true);

        target.gameObject.SetActive(false); 
        soundmanager.instance.playdiesound();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag==mytags.obstacle)
        {
            print(trextrigger);
            if(!trextrigger)
            {
                diewithobstacles(target);
            }
            else
            {
                destroyobstacles(target);
            }
            
        }

        if (target.tag == mytags.trex)
        {
            trextrigger = true;
            playerrenderer.sprite = trexsprite;
            target.gameObject.SetActive(false);

            StartCoroutine(terxduration());
            soundmanager.instance.playpowerupsound();
        }

        if (target.tag == mytags.star) 
        {
            for (int i=0; i < stareffects.Length;i++)
            {
                if (!stareffects[i].activeInHierarchy)
                {
                    stareffects[i].transform.position = target.transform.position;
                    stareffects[i].SetActive(true);
                    break;
                }
            }
            target.gameObject.SetActive(false);
            soundmanager.instance.playcoinsound();
            GameplayController.instance.updatestarscore();
        }
        
    }
}
