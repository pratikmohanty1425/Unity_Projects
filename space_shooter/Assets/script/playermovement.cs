using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed = 5;
    
    public float minx,maxx,miny;

    [SerializeField]
    private GameObject bullet = null;
    [SerializeField]
    private Transform[] attack_point = null;

    private Animator anim;

    public float attack_timer = 0.35f;
    private float crnt_timer;
    private bool canattack=false;

    public static playermovement instaniate;

    private void Awake()
    {
        if (instaniate == null)
        {
            instaniate = this;
        }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        crnt_timer = attack_timer;
    }

    void Update()
    {
        playermove();
        attack();
    }

    void playermove()
    {        
        if (Input.GetAxis("Horizontal") > 0)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            if(temp.x>maxx)
            {
                temp.x = maxx;
            }
            transform.position = temp;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            if (temp.x < minx)
            {
                temp.x = minx;
            }
            transform.position = temp;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;
            
            transform.position = temp;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            if (temp.y < miny)
            {
                temp.y = miny;
            }
            transform.position = temp;
        }

    }

    void attack()
    {
        attack_timer += Time.deltaTime;
        if (attack_timer > crnt_timer)
        {
            canattack = true;
        }
        if (Input.GetMouseButtonDown(0))
        {            
            anim.SetTrigger("fire");
            if (canattack)
            {
                canattack = false;
                attack_timer = 0;
                Instantiate(bullet, attack_point[Random.Range(0, attack_point.Length)].position, Quaternion.Euler(new Vector3(0, 0, 90)));

            }
            
        }
        else
        {
            anim.SetTrigger("end");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            boom();
            enemy.instaniate.boom();
            Destroy(gameObject, 3);
            Destroy(collision.gameObject, 3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="enemybullets")
        {
            boom();
            Destroy(gameObject, 3);
            Destroy(collision.gameObject);
        }
    }

    public void boom()
    {
        anim.SetBool("blown", true);
    }
}
