using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public int cid;
    public string chname;

    public float health;
    public float shield;
    public float maxhealth;
    public float maxshield;
    public float initialX;
    public float initialZ;
    public float distance=1;

    public GameObject weapon;

    public Animator anim;
    public Transform target;
    public bool isfollowing { get; set; }

    public float timeattackstart = -1;
    public float timedie = -1;

    public virtual void Awake()
    {
        health = 10;
        shield = 10;
        maxhealth = 10;
        maxshield = 10;
        target = null;
        initialX = transform.position.x;
        initialZ = transform.position.z;
        anim = transform.GetComponent<Animator>();
    }
    
     
    public virtual void Update()
    {
        if (gettarget() != null && Vector3.Distance(transform.position, target.position) > 1 ) 
        {
            Vector3 lookat = target.position;
            lookat.y = 0;
            transform.LookAt(lookat);
        }

        if(isdead())
        {
            die();
        }
    }
    public void settarget(Transform target)
    {
        this.target = target;
        if (target == null)
        {
            isfollowing = false;
        }
    }

    public Transform gettarget()
    {
        return target;
    }
    public bool isattackin()
    {
        return Time.timeSinceLevelLoad - timeattackstart < 0.2f;
    }
    public void updateweapon()
    {
        weapon.SetActive(isattackin());
    }
    public bool hastarget()
    {
        return target != null;
    }

    public bool isdead()
    {
        return health <= 0;
    }

    public void die()
    {
        if(timedie<0)
        {
            timedie = Time.timeSinceLevelLoad;
            anim.SetBool("Die", true);
            target = null;
            isfollowing = false;
        }

        if(Time.timeSinceLevelLoad-timedie>2)
        {
            transform.localScale = Vector3.zero;
        }
    }

    public virtual void respawn()
    {
        transform.position = new Vector3(initialX, 0, initialZ);
        anim.SetBool("Die", false);
        transform.localScale = Vector3.one;
        timedie = -1;
        health = maxhealth;
    }
}
