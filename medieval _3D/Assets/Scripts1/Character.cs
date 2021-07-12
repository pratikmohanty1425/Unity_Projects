using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int characterId;
    public string characterName;

    public int health;
    public int mana;
    public int maxHealth;
    public int maxMana;
    public float initialX;
    public float initialZ;

    public Animator animator;

    public Transform target;
    public bool IsFollowTarget { get; set; }

    public GameObject weapon;

    public float timeAttackStart = -1;
    public float timeDie = -1;

    public virtual void Awake()
    {
        initialX = transform.position.x;
        initialZ = transform.position.z;
        animator = transform.GetComponent<Animator>();
        maxHealth = 10;
        maxMana = 10;
        health = 10;
        mana = 10;
        target = null;
    }

    public virtual void Update()
    {
        if (GetTarget() != null && Vector3.Distance(transform.position, target.position) > 1f)
        {
            Vector3 lookAt = target.position;
            lookAt.y = 0;
            transform.LookAt(lookAt);
        }

        if (IsDead())
        {
            Die();
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
        if (target == null)
        {
            IsFollowTarget = false;
        }
    }

    public Transform GetTarget()
    {
        return target;
    }

    public bool IsAttacking()
    {
        return Time.timeSinceLevelLoad - timeAttackStart < 0.2f;
    }

    public void UpdateWeapon()
    {
        weapon.SetActive(IsAttacking());
    }

    public bool HasTarget()
    {
        return target != null;
    }
    
    public bool IsDead()
    {
        return health <= 0;
    }

    public void Die()
    {
        timeDie = Time.timeSinceLevelLoad;
        if (timeDie < 0)
        {
            timeDie = Time.timeSinceLevelLoad;
            animator.SetBool("Die", true);
            target = null;
            IsFollowTarget = false;
        }

        if (Time.timeSinceLevelLoad - timeDie > 2f)
        {
            transform.localScale = Vector3.zero;
        }
    }

    public virtual void Respawn()
    {
        transform.position = new Vector3(initialX, 0, initialZ);
        animator.SetBool("Die", false);
        transform.localScale = Vector3.one;
        timeDie = -1;
        health = maxHealth;
    }
}
