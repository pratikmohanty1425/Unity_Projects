using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public static enemy instance;
    public GameObject ground = null;
    public GameObject crater = null;
    public GameObject explosion;
    public Transform explosionpoint;
    public GameObject hitpoint;
    int count = 0;
    private void Awake()
    {
       // explosion.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }
        ground = GameObject.FindGameObjectWithTag("Ground");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 offset= new Vector3(1f, 1f, 1f); ;

        if (collision.gameObject.tag == "Ground"&&count==0)
        {
            Instantiate(explosion, explosionpoint.transform.position, transform.rotation);
            StartCoroutine("craterins");

            GameObject c = Instantiate(crater, hitpoint.transform.position, transform.rotation);
            
                c.transform.parent = ground.transform;
            
            
            Destroy(this.gameObject);
            count++;
        }

        if (collision.gameObject.tag == "crator")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator craterins()
    {
        yield return new WaitForSeconds(1);
    }
}
