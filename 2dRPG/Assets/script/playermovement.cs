using System.Data.SqlTypes;
using System.Security.Cryptography;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public GameObject panel = null;
    public Vector2 lastpos;
    private Animator anim;
    private Rigidbody2D mybody;

    public float movespeed;
    public float attackingtime;

    public string startpoint;


    private bool playermoving;
    private static bool playerexist;
    private bool attacking;

    private float attackingtimercounter;

    public static playermovement player;

    private void Awake()
    {
        if(player==null)
        {
            player = this;
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();

        if(!playerexist)
        {
            playerexist = true;
            DontDestroyOnLoad(transform.gameObject);
            DontDestroyOnLoad(panel);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        playermoving = false;

        if(!attacking)
        {
            move();
        }

        if(attackingtimercounter>0)
        {
            attackingtimercounter -= Time.deltaTime;
        }

        if(attackingtimercounter <= 0)
        {
            attacking = false;
            anim.SetBool("PlayerAttacking", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            attackingtimercounter = attackingtime;
            attacking = true;
            mybody.velocity = Vector3.zero;
            anim.SetBool("PlayerAttacking", true);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playermoving);
        anim.SetFloat("LastMoveX", lastpos.x);
        anim.SetFloat("LastMoveY", lastpos.y);
    }

    void move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f ||
                Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            mybody.velocity = new Vector2(
                Input.GetAxisRaw("Horizontal") * movespeed,
                mybody.velocity.y);
            playermoving = true;
            lastpos = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f ||
                Input.GetAxisRaw("Vertical") < -0.5f)
        {
            mybody.velocity = new Vector2(
                mybody.velocity.x,
                Input.GetAxisRaw("Vertical") * movespeed);
            playermoving = true;
            lastpos = new Vector2(0, Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f &&
                Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            mybody.velocity = new Vector2(
                0f,
                mybody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f &&
                Input.GetAxisRaw("Vertical") > -0.5f)
        {
            mybody.velocity = new Vector2(
                mybody.velocity.x, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pickable1")
        {
            score.instance.scores();
            PlayerHPmanager.instance.playerCurrentHealth += 20;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Pickable2")
        {
            score.instance.scores();
            PlayerHPmanager.instance.playerCurrentHealth += 30;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Pickable3")
        {
            score.instance.scores();
            PlayerHPmanager.instance.playerCurrentHealth += 40;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "finishline")
        {
            Time.timeScale = 0f;
        }
    }
}
