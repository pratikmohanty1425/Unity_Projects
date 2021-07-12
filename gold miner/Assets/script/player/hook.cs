using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook : MonoBehaviour
{
    [SerializeField]
    private Transform itemholder;

    private bool itemattached;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tags.smalgold ||
            collision.tag == tags.mediumgold ||
            collision.tag == tags.largegold  ||
            collision.tag == tags.smallstone ||
            collision.tag == tags.mediumstone)
        {
            itemattached = true;
            collision.transform.parent = itemholder;
            collision.transform.position = itemholder.position;

            hookmovement.instance.movespeed = collision.GetComponent<items>().hookspeed;
            hookmovement.instance.hookattached();

            player.instance.ropeanim();

            if (collision.tag == tags.smalgold ||
                collision.tag == tags.mediumgold ||
                collision.tag == tags.largegold)
            {
                soundmanager.instance.goldfx();
            }
            else if (collision.tag == tags.smallstone ||
                collision.tag == tags.mediumstone)
            {
                soundmanager.instance.stonefx();
            }

            soundmanager.instance.ropefx(true);
        }
        if (collision.tag == tags.deliveritem)
        {
            Debug.Log("hit");
            if (itemattached)
            {
                player.instance.idealanim();
                itemattached = false;

                Transform objchild = itemholder.GetChild(0);

                objchild.parent = null;
                objchild.gameObject.SetActive(false);
                soundmanager.instance.ropefx(true);
            }
        }
    }
}
