using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    private playeranimation anim;
    private Rigidbody mybody;
    public float speed = 5f;

    private Transform playertarget;

    public float attackdistance = 1;
    private float chaseplayerafterattack = 1;

    private float currentattacktime;
    private float defaultattacktime = 2;

    private bool followplayer, attackplayer;

    private void Awake()
    {
        anim = GetComponentInChildren<playeranimation>();
        mybody = GetComponent<Rigidbody>();
        playertarget = GameObject.FindWithTag(tags.playertag).transform;
    }

    void Start()
    {
        followplayer = true;
        currentattacktime = defaultattacktime;
    }

    private void Update()
    {
        attack();
    }

    void FixedUpdate()
    {
        followtarget();
    }

    void followtarget()
    {
        if (!followplayer)
        {
            return;
        }

        if (Vector3.Distance(transform.position, playertarget.position) > attackdistance)
        {
            transform.LookAt(playertarget);
            mybody.velocity = transform.forward * speed;
            if (mybody.velocity != Vector3.zero)
            {
                anim.walk(true);
            }
        }
        else if(Vector3.Distance(transform.position, playertarget.position) <= attackdistance)
        {
            mybody.velocity = Vector3.zero;
            anim.walk(false);
            followplayer = false;
            attackplayer = true;
        }
    }

    void attack()
    {
        if (!attackplayer)
        {
            return;
        }

        currentattacktime += Time.deltaTime;

        if (currentattacktime > defaultattacktime)
        {
            anim.enemyattack(Random.Range(0, 3));
            currentattacktime = 0;
        }

        if (Vector3.Distance(transform.position, playertarget.position) > chaseplayerafterattack+attackdistance)
        {
            attackplayer = false;
            followplayer = true;
        }
    }
}
