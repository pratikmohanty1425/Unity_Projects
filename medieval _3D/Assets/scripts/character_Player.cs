using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_Player : character
{
    CharacterController characterController;

    public float speed = 6;
    public float jumpspeed = 8;
    public float gravity = 20;
    Vector3 movement;
    Quaternion rot = Quaternion.identity;
    private Vector3 movedirection = Vector3.zero;

    float attackdelay = 1;

    public override void Awake()
    {
        base.Awake();

        weapon = transform.Find("PlayerWeapon").gameObject;
        characterController = GetComponent<CharacterController>();
        chname = "pratik";
        settarget(gameObject.transform);
    }
    
    public override void Update()
    {
        base.Update();
        updateweapon();
        if(isdead())
        {
            respawn();
            if (Time.timeSinceLevelLoad - timedie > 9) 
            {
                respawn();
            }
        }
        else
        {
            checkmovement();
            checkattack();
        }
    }

    void checkattack()
    {
        if(Time.time-timeattackstart>attackdelay)
        {
            if(Input.GetButton("Fire1"))
            {
                anim.SetTrigger("Attack");
                timeattackstart = Time.time;
            }
        }    
    }

    void checkmovement()
    {
        if(characterController.isGrounded)
        {
            movedirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            movedirection *= speed;

            if(Input.GetButton("Jump"))
            {
                movedirection.y = jumpspeed;
                anim.SetTrigger("Jump");
            }
        }
        movement.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        movement.Normalize();

        Vector3 desiredforward = Vector3.RotateTowards(transform.forward, movement, 30 * Time.deltaTime, 0);
        rot = Quaternion.LookRotation(desiredforward);
        transform.rotation = rot;

        movedirection.y -= gravity * Time.deltaTime;

        characterController.Move(movedirection * Time.deltaTime);
        anim.SetFloat("Move", movement.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="Weapon")
        {
            health -= 1;
        }
    }
}
