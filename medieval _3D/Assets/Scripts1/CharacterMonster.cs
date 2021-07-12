using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMonster : CharacterNonPlayer
{
    public NavMeshAgent navMeshAgent;

    float timeSetTarget;
    float timeLastWaypoint;
    float timeToNextWaypoint;

    public override void Awake()
    {
        base.Awake();

        weapon = transform.Find("Weapon").gameObject;

        Vector3 next = NextWaypoint();
        navMeshAgent.SetDestination(next);
        transform.rotation = Quaternion.LookRotation(new Vector3(0, Random.Range(0f, 90f), 0));
        IsFollowTarget = true;
    }

    public  void Start()
    {
        maxHealth = 4;
        health = 4;

    }

    public override void Update()
    {
        base.Update();
        UpdateWeapon();
        animator.SetBool("Move", !Vector3.Equals(navMeshAgent.velocity, Vector3.zero));

        if (HasTarget())
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance <= 2.8f)
            {
                Attack();
            }

            if (IsFollowTarget)
            {
                navMeshAgent.SetDestination(target.position);

                if (distance <= 2f)
                {
                    IsFollowTarget = false;
                    StopNav();
                }
            }
            else
            {
                if (distance > 2f)
                {
                    IsFollowTarget = true;
                    StartNav();
                }
            }

        }
        else
        {
            if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                if (Time.timeSinceLevelLoad - timeLastWaypoint > timeToNextWaypoint)
                {
                    timeLastWaypoint = Time.timeSinceLevelLoad;
                    timeToNextWaypoint = 5f;
                    Vector3 next = NextWaypoint();
                    navMeshAgent.SetDestination(next);
                }
            }
            if (Time.timeSinceLevelLoad - timeLastWaypoint > 8f)
            {
                timeLastWaypoint = Time.timeSinceLevelLoad;
                timeToNextWaypoint = 5f;
                navMeshAgent.SetDestination(new Vector3(initialX, 0, initialZ));
            }
        }

        if (IsDead())
        {
            StopNav();
            if (Time.timeSinceLevelLoad - timeDie > 9f)
            {
                Respawn();
            }
        }
    }

    Vector3 NextWaypoint()
    {
        return new Vector3(initialX + Random.Range(-4f, 4f), 0, initialZ + Random.Range(-4f, 4f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerWeapon")
        {
            health -= 1;
            Transform player = other.transform.parent.GetComponent<Transform>();
            SetTarget(player);
            IsFollowTarget = true;
        }
    }

    private void StopNav()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.velocity = Vector3.zero;
    }

    private void StartNav()
    {
        navMeshAgent.isStopped = false;
    }

    private void Attack()
    {
        if (Time.timeSinceLevelLoad - timeAttackStart > 1.8f)
        {
            timeAttackStart = Time.timeSinceLevelLoad;
            animator.SetTrigger("Attack");
        }
        if (HasTarget())
        {
            if (target.GetComponent<Character>().IsDead())
            {
                SetTarget(null);
                StartNav();
            }
        }
    }

    public override void Respawn()
    {
        base.Respawn();
        StartNav();
    }
}
