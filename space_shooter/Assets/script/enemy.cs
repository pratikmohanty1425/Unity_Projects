using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public float speed = 5;
    public float rotate_speed = 50;

    public bool canshoot;
    public bool canrotate;
    private bool canmove = true;

    public float boundy = -5;

    [SerializeField]
    private GameObject bullet = null;
    [SerializeField]
    private Transform[] attack_point = null;

    private Animator anim;

    private AudioSource explosion;

    public float attack_timer = 0.35f;
    private float crnt_timer;
    private bool canattack = false;

    public static enemy instaniate;

    private void Awake()
    {
        if (instaniate == null)
        {
            instaniate = this;
        }
        explosion = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        if(canrotate)
        {
            if(Random.Range(0,2)>0)
            {
                rotate_speed = Random.Range(rotate_speed, rotate_speed + 20);
                rotate_speed += -1;
            }
        }
        if (canshoot)
        {
            Invoke("attack", Random.Range(0f, 1f));
        }
    }

    void Update()
    {
        move();
        rotate_enemy(); 
        
    }

    void move()
    {
        if(canmove)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            if (temp.y < boundy)
            {
                Destroy(gameObject,1);
            }
            transform.position = temp;
        }
    }

    void attack()
    {
        Instantiate(bullet, attack_point[Random.Range(0, attack_point.Length)].position, Quaternion.Euler(new Vector3(0, 0, 90)));


        if (canshoot)
        {
            Invoke("attack", Random.Range(0, 1f));
        }
    }

    void rotate_enemy()
    {
        if(canrotate)
        {
            transform.Rotate(new Vector3(0,0,rotate_speed * Time.deltaTime), Space.World);
        }
    }

    int cnt = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "enemy")
            {
                atroidhit(1);
            }
            else if (gameObject.tag == "enemy1" )
            {
                atroidhit(2);
            }
            else if (gameObject.tag == "enemyplane")
            {
                boom();
            }

            playermovement.instaniate.boom();
            Destroy(gameObject,3);
            Destroy(collision.gameObject, 3);
            gameover();
        }

        if(collision.gameObject.tag=="bullets")
        {
            if (gameObject.tag == "enemy")
            {
                cnt++;
                if(cnt==3)
                {
                    Destroy(gameObject, 1);
                    atroidhit(1);
                }
                Destroy(collision.gameObject);
            }
            else if (gameObject.tag == "enemy1")
            {
                cnt++;
                if (cnt == 5)
                {
                    Destroy(gameObject, 1);
                    atroidhit(2);
                }
                Destroy(collision.gameObject);
            }
            else if (gameObject.tag == "enemyplane")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject, 1);
                boom();
            }
        }
    }


    public void boom()
    {
        anim.SetBool("hits", true);
    }

    public void atroidhit(int i)
    {
        if(i==1)
        {
            anim.SetTrigger("baam");
        }

        if(i==2)
        {
            anim.SetBool("boomit", true);
        }
    }
    
    public void gameover()
    {
        speed = 0.2f * Time.deltaTime;
        canshoot = false;
        Invoke("restartgame", 2);
    }

    void restartgame()
    {
        SceneManager.LoadScene(0);
    }
}
