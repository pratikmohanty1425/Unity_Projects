using UnityEngine;
using UnityEngine.SceneManagement;

public class enemycontroller : MonoBehaviour
{
    public float movespeed;
    private Rigidbody2D rb;

    private bool moving;

    public float timebtnmove;
    private float timebtnmovecounter;

    public float timetomove;
    private float timetomovecounter;

    private Vector3 movedir;

    public float waittoreload;
    private bool reload;

    private GameObject theplayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        timebtnmovecounter = Random.Range(timebtnmove * 0.75f, timebtnmove * 1.25f);
        timetomovecounter = Random.Range(timetomove * 0.75f, timetomove * 1.25f);
    }

    void Update()
    {
        if(moving)
        {
            timetomovecounter -= Time.deltaTime;
            rb.velocity = movedir;

            if(timetomovecounter<0)
            {
                moving = false;
                timebtnmovecounter = Random.Range(timebtnmove * 0.75f, timebtnmove * 1.25f);

            }
        }
        else
        {
            timebtnmovecounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;

            if(timebtnmovecounter<0)
            {
                moving = true;
                timetomovecounter = Random.Range(timetomove * 0.75f, timetomove * 1.25f);
                movedir = new Vector3(Random.Range(-1, 1) * movespeed,
                    Random.Range(-1, 1) * movespeed);

            }
        }

        if(reload)
        {
            waittoreload -= Time.deltaTime;
            if(waittoreload<0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                theplayer.SetActive(false);
            }
        }
    }
}
