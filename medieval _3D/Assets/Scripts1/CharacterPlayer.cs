using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayer : Character
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    Vector3 movement;
    Quaternion rotation = Quaternion.identity;
    private Vector3 moveDirection = Vector3.zero;

    float attackDelay = 1f;

    public override void Awake()
    {
        base.Awake();

        weapon = transform.Find("PlayerWeapon").gameObject;
        characterController = GetComponent<CharacterController>();

        characterName = "Billy";
    }

    public override void Update()
    {
        base.Update();
        UpdateWeapon();

        if (IsDead())
        {
            if (Time.timeSinceLevelLoad - timeDie > 9f)
            {
                Respawn();
            }
        }
        else
        {
            CheckMovement();
            CheckAttack();
        }
    }

    void CheckAttack()
    {
        if (Time.time - timeAttackStart > attackDelay)
        {
            if (Input.GetButton("Fire1"))
            {
                Debug.Log("Attack");
                animator.SetTrigger("Attack");
                timeAttackStart = Time.time;
            }
        }
    }

    void CheckMovement()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                animator.SetTrigger("Jump");
            }
        }

        // Rotation
        movement.Set(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        movement.Normalize();
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, 30f * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredForward);
        transform.rotation = rotation;

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        animator.SetFloat("Move", movement.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Weapon")
        {
            health -= 1;
        }
    }
}
