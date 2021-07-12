using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

public class spikes : MonoBehaviour
{
    [SerializeField]
    private Transform[] spikess;

    [SerializeField]
    private GameObject coin;

    private bool falldown;
    void Start()
    {
        activateplatform();
    }

    void activatespike()
    {
        int index = Random.Range(0, spikess.Length);
        spikess[index].gameObject.SetActive(true);

        spikess[index].DOLocalMoveY(1.15f,1.3f).SetLoops(-1,LoopType.Yoyo)
            .SetDelay(Random.Range(3,5));
    }

    void addcoin()
    {
        GameObject coins = Instantiate(coin);
        coins.transform.position = transform.position;
        coins.transform.SetParent(transform);
        coins.transform.DOLocalMoveY(0.5f,0);
    }

    void activateplatform()
    {
        int chance = Random.Range(0, 100);

        if(chance>50)
        {
            int type = Random.Range(0, 8);

            if(type == 0)
            {
                activatespike();
            }
            else if(type == 1)
            {
                addcoin();
            }
            else if (type == 2)
            {
                falldown = true;
            }
            else if (type == 3)
            {

            }
            else if (type == 4)
            {

            }
            else if (type == 5)
            {
                addcoin();
            }
            else if (type == 6)
            {
            }
            else if (type == 7)
            {
                addcoin();
            }
        }
    }

    void falling()
    {
        gameObject.AddComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(falldown)
            {
                falldown = false;
                Invoke("falling", 1.5f);
            }
        }
    }
}
