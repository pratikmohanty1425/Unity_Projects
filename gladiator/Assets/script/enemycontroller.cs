using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum enemystate
{
    chase,
    attack
}

public class enemycontroller : MonoBehaviour
{
    private NavMeshAgent navagent;

    public Transform player;

    public float movespeed = 3.5f;

    public float attackdistance = 1;
    public float chaseplayerafterattackdistance = 1;

    private float waitbeforeattacktime = 3;
    private float attacktimer;

    private enemystate enemy;

    public GameObject attackpoint;
    private sound sfx;

    private void Awake()
    {
        navagent = GetComponent<NavMeshAgent>();
        sfx = GetComponentInChildren<sound>();
    }

    private void Start()
    {
        enemy = enemystate.chase;
        attacktimer = waitbeforeattacktime;
    }

    void Update()
    {
        if (enemy == enemystate.chase)
        {
            chaseplayer();
        }

        if (enemy == enemystate.attack)
        {
            attackplayer();
        }
    }

    void chaseplayer()
    {
        navagent.SetDestination(player.position);
        navagent.speed = movespeed;

        if(navagent.velocity.sqrMagnitude == 0)
        {
            enemyanim.instance.walk(false);
        }
        else
        {
            enemyanim.instance.walk(true);
        }

        if(Vector3.Distance(transform.position,player.position)<=attackdistance)
        {
            enemy = enemystate.attack;
        }
    }

    void attackplayer()
    {
        navagent.velocity = Vector3.zero;
        navagent.isStopped = true;
        enemyanim.instance.walk(false);

        attacktimer += Time.deltaTime;

        if(attacktimer>waitbeforeattacktime)
        {
            int i = Random.Range(1, 4);
            enemyanim.instance.attack(i);
            attacktimer = 0;
            if (i == 1)
            {
                sfx.at1();
            }
            else if (i == 2)
            {
                sfx.at2();
            }
            else if (i == 3)
            {
                sfx.at3();
            }

        }
        if(Vector3.Distance(transform.position,player.position)>attackdistance+chaseplayerafterattackdistance)
        {
            navagent.isStopped = false;
            enemy = enemystate.chase;
        }
    }
    void activateaatackpoint()
    {
        attackpoint.SetActive(true);
    }
    void deactivateaatackpoint()
    {
        if (attackpoint.activeInHierarchy)
        {
            attackpoint.SetActive(false);
        }
    }
}
