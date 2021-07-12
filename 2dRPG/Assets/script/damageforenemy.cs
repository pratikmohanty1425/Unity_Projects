using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageforenemy : MonoBehaviour
{
    public float damagetogive;
    public GameObject damageburst;
    public Transform hitpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            collision.gameObject.GetComponent<EnemyHpManager>().DmgEnemy(damagetogive);
            Instantiate(damageburst,hitpoint.position, hitpoint.rotation);
        }
    }
}
