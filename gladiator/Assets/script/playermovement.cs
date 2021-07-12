using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private CharacterController character;
    
    public float movementspeed=3;
    public float gravity = 9.8f;
    public float rotationspeed = 0.15f;
    public float rotatedegreespersecond = 180;

    void Awake()
    {
        character = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        
    }
   

    void Update()
    {
        move();
        rotate();
        animwalk();
    }

    void move()
    {

        if (Input.GetAxis("Vertical") > 0)
        {
            Vector3 moved = transform.forward;
            moved.y -= gravity * Time.deltaTime;
            character.Move(moved * movementspeed * Time.deltaTime);

        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            Vector3 moved = -transform.forward;
            moved.y -= gravity * Time.deltaTime;
            character.Move(moved * movementspeed * Time.deltaTime);
        }
        else
        {
            character.Move(Vector3.zero);
        }
    }

    void rotate()
    {
        Vector3 rot = Vector3.zero;

        if(Input.GetAxis("Horizontal") < 0)
        {
            rot = transform.TransformDirection(Vector3.left);
        }
        
        if(Input.GetAxis("Horizontal") > 0)
        {
            rot = transform.TransformDirection(Vector3.right);
        }

        if(rot!=Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rot), rotatedegreespersecond * Time.deltaTime);
        }
    }

    void animwalk()
    {
        if(character.velocity.sqrMagnitude!=0)
        {
            animations.instance.walk(true);
        }

        else
        {
            animations.instance.walk(false);
        }
    }
}
