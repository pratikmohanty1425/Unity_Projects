using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageforplayer : MonoBehaviour
{
    public float damagetogive;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHPmanager>().DmgPlayer(damagetogive);
        }
    }
}
