using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmovment : MonoBehaviour
{
    private Vector3 mypos;
    public float speed = 2;
    public GameObject explosion;
    public AudioSource acc;
    private void Start()
    {
        mypos = transform.position;
        explosion.SetActive(false);
    }
    void Update()
    {        
        if(i==0)
        {
            mypos.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
            mypos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.position = mypos;
        }
        
    }

    int i = 0;
    public static int q=0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            //Time.timeScale = .5f * Time.deltaTime;
            Vector2 pos = transform.position;
            explosion.transform.position = new Vector3(pos.x, pos.y, -1);
            i = 1;
            q = 1;
            explosion.SetActive(true);
            acc.Stop();
        }
    }
}
