using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
    public Sprite[] runsprite;
    public Sprite[] jumpsprite;
    public Text score;
    public Text high_score;
    public AudioClip jumpsound, impactsound, scoresound;

    public SpriteRenderer renderer;
    Rigidbody2D rb;
    public gameplaycontroller game;

    AudioSource sound;

    bool jumping = true;
    static bool gameover = false;
    int scores = 0;
    int high = 0;
    float runtime = 0;
    int runanim = 0;
    int qncnt = 0;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        //game = GetComponent<gameplaycontroller>();
        game = GameObject.FindGameObjectWithTag("gameplaycontroller").GetComponent<gameplaycontroller>();

        high_score.text = "High Score = " + (PlayerPrefs.GetInt("high")).ToString();

        sound = GetComponent<AudioSource>();

        gameover = false;
    }


    void Update()
    {
        if(jumping)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.gravityScale = 1;
                rb.AddForce(new Vector2(0, 450));
                sound.clip = jumpsound;
                sound.Play();
                jumping = false;
            }
        }
        

        if(!gameover)
        {
            runninganim();
        }
        else
        {
            
        }
    }

    void runninganim()
    {
        runtime += Time.deltaTime;
        if(jumping)
        {
            renderer.sprite = runsprite[runanim++];
            if(runanim==18)
            {
                runanim = 0;
            }
        }
        else
        {
            if (rb.velocity.y > 0)
            {
                renderer.sprite = jumpsprite[0];
            }
            else
            {
                renderer.sprite = jumpsprite[1];
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "scorebar")
        {
            scores++;
            score.text = "Score = " + scores.ToString();
            sound.clip = scoresound;
            sound.Play();
            Time.timeScale += 0.3f;
        }

        if(collision.gameObject.tag=="obstacle")
        {
            Time.timeScale = 1;

            sound.clip = impactsound;
            sound.Play();

            gameover = true;
            game.gameover();

            high = PlayerPrefs.GetInt("high");
            if (scores > high) 
            {
                PlayerPrefs.SetInt("high", scores);
            }
            //qncnt++;
            //qncnt += PlayerPrefs.GetInt("qncnt");
            //PlayerPrefs.SetInt("qncnt", qncnt);

        }

        if(collision.gameObject.tag=="ground")
        {
            rb.gravityScale = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = true;
    }
}
