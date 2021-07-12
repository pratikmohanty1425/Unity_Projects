using UnityEngine;

public class bullets : MonoBehaviour
{
    public float speed = 5;
    public float deactivate_Timer = 3;

    public static bool player=false;
    public static bool enemies = false;

    public int turn = 1;
    public static bullets instaniate;

    private void Awake()
    {
        if(instaniate== null)
        {
            instaniate = this;
        }
    }

    void Start()
    {
        Destroy(gameObject, 3);
    }
    
    void Update()
    {
        move();
    }

    void move()
    {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime * turn;
        transform.position = temp;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag=="Player" && turn == -1)
    //    {
    //        playermovement.instaniate.boom();
    //        enemy.instaniate.gameover();
    //        Destroy(collision.gameObject, 3);
    //    }

    //    if(collision.gameObject.tag=="enemy" && turn == 1)
    //    {
    //        enemy.instaniate.atroidhit(1);
    //        Destroy(gameObject);
    //        Destroy(collision.gameObject,3);
    //    }

    //    if (collision.gameObject.tag == "enemy1" && turn == 1)
    //    {
    //        enemy.instaniate.atroidhit(2);
    //        Destroy(gameObject);
    //        Destroy(collision.gameObject, 3);
    //    }

    //    if (collision.gameObject.tag == "enemyplane" && turn == 1)
    //    {
    //        enemy.instaniate.boom();
    //        Destroy(gameObject);
    //        Destroy(collision.gameObject, 3);
    //    }
    //}
}
