using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocoMotion : MonoBehaviour
{
    Vector3 movedirection;
    Transform cam;
    //Rigidbody rb;
    CharacterController character;

    public float movementspeed = 7;
    public float rotationspeed = 15;

    public static PlayerLocoMotion instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        character = GetComponent<CharacterController>();
    }

    public void HandleAllMovement()
    {
        HandelMovment();
        handledirection();
    }

    private void HandelMovment()
    {
        movedirection = cam.forward * InputManager.instance.verticalinput;
        movedirection = movedirection + cam.right * InputManager.instance.Horizontalinput;
        movedirection.Normalize();
        movedirection.y = 0;
        movedirection *= movementspeed;

        Vector3 movementvelocity = movedirection;
        character.Move(movementvelocity * Time.deltaTime);
        //rb.velocity = movementvelocity;
    }

    private void handledirection()
    {
        Vector3 targetdirection = Vector3.zero;

        targetdirection = cam.forward * InputManager.instance.verticalinput;
        targetdirection = targetdirection + cam.right * InputManager.instance.Horizontalinput;
        targetdirection.Normalize();
        targetdirection.y = 0;

        if(targetdirection == Vector3.zero)
        {
            targetdirection = transform.forward;
        }

        Quaternion targetrotation = Quaternion.LookRotation(targetdirection);
        Quaternion playerrotation = Quaternion.Slerp(transform.rotation, targetrotation, rotationspeed * Time.deltaTime);

        //character.transform.rotation = playerrotation;

        transform.rotation = playerrotation;
    }
}
