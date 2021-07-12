using UnityEngine;
using UnityEngine.AI;

public class enemy : character_non_player
{
    public NavMeshAgent navmeshagent;
    float timesettarget;
    float timelastwaypoint;
    float timetonextwaypoint;

    public override void Awake()
    {
        base.Awake();
        weapon = transform.Find("Weapon").gameObject;

        Vector3 next = nextwaypoint();
        navmeshagent.SetDestination(next);
        transform.rotation = Quaternion.LookRotation(new Vector3(0, Random.Range(0, 90),0));
        isfollowing = true;
    }

    private void Start()
    {
        maxhealth = 4;
        health = 4;
    }
    public override void Update()
    {
        base.Update();
        updateweapon();
        anim.SetBool("Move", !Vector3.Equals(navmeshagent.velocity, Vector3.zero));

        if(hastarget())
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if(distance<2.8f)
            {
                attack();
            }
            if(isfollowing)
            {
                navmeshagent.SetDestination(target.position);
                if(distance<=2)
                {
                    isfollowing = false;
                    stopnav();
                }
            }
            else
            {
                if (distance > 2)
                {
                    isfollowing = true;
                    startnav();
                }
            }
        }
        else
        {
            if (navmeshagent.remainingDistance < navmeshagent.stoppingDistance) 
            {
                if (Time.timeSinceLevelLoad - timelastwaypoint > timelastwaypoint) 
                {
                    timelastwaypoint = Time.timeSinceLevelLoad;
                    timetonextwaypoint = 5;
                    Vector3 next = nextwaypoint();
                    navmeshagent.SetDestination(next);
                }
            }

            if(Time.timeSinceLevelLoad - timelastwaypoint > timelastwaypoint)
            {
                timelastwaypoint = Time.timeSinceLevelLoad;
                timetonextwaypoint = 5;
                navmeshagent.SetDestination(new Vector3(initialX, 0, initialZ));
            }
        }

        if(isdead())
        {
            stopnav();
            if(Time.timeSinceLevelLoad-timedie>9)
            {
                respawn();
            }
        }

    }

    Vector3 nextwaypoint()
    {
        return new Vector3(initialX + Random.Range(-4,4), 0, initialZ + Random.Range(-4, 4));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="PlayerWeapon")
        {
            health -= 1;
            Transform player = other.transform.parent.GetComponent<Transform>();
            settarget(player);
            isfollowing = true;
        }
    }
    void stopnav()
    {
        navmeshagent.isStopped = true;
        navmeshagent.velocity = Vector3.zero;
    }

    void startnav()
    {
        navmeshagent.isStopped = false;
    }

    void attack()
    {
        if(Time.timeSinceLevelLoad-timeattackstart>1)
        {
            timeattackstart = Time.timeSinceLevelLoad;
            anim.SetTrigger("Attack");
        }

        if(hastarget())
        {
            if(target.GetComponent<character>().isdead())
            {
                settarget(null);
                startnav();
            }
        }
    }

    public override void respawn()
    {
        base.respawn();
        startnav();
    }
}
