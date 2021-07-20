using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    public GameObject Fppcam;
    public GameObject Tppcam;

    public float speed = 12f;
    public float sprintspeed = 12f;
    public float gravity = -9.8f;

    private float mDesiredRotation = 0;
    public float rotationspeed = 15;

    private Animator animator;
    private int vertical;

    private float mDesiredanimationspeed = 0;
    private float MoveAmount=0;
    public float animationbledspeed=2;

    private bool msprinting = false;

    private void Awake() { 
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        vertical = Animator.StringToHash("Vertical");
    }

    void Update()
    {
        float x;
        float z;
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        msprinting = Input.GetKey(KeyCode.LeftShift);

        Vector3 movement = new Vector3(x, 0, z).normalized;

        Vector3 rotationMovement;
        if (Fppcam.activeInHierarchy)
        {
            rotationMovement = Quaternion.Euler(0, Fppcam.transform.rotation.eulerAngles.y, 0) * movement;
        }
        else
        {
            rotationMovement = Quaternion.Euler(0, Tppcam.transform.rotation.eulerAngles.y, 0) * movement;
        }

        controller.Move(rotationMovement * (msprinting ? sprintspeed : speed) * Time.deltaTime);

        if (rotationMovement.magnitude > 0)
        {
            mDesiredRotation = Mathf.Atan2(rotationMovement.x, rotationMovement.z) * Mathf.Rad2Deg;
            mDesiredanimationspeed = msprinting?1:0.5f;
        }
        else
        {
            mDesiredanimationspeed = 0;
        }

        //MoveAmount = Mathf.Clamp01(Mathf.Abs(x) + Mathf.Abs(z));
        //animator.SetFloat(vertical, MoveAmount, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical,Mathf.Lerp(animator.GetFloat(vertical),mDesiredanimationspeed,animationbledspeed * Time.deltaTime));
        Quaternion currentrotation = transform.rotation;
        Quaternion targetrotation = Quaternion.Euler(0, mDesiredRotation, 0);
        transform.rotation = Quaternion.Lerp(currentrotation, targetrotation, rotationspeed * Time.deltaTime);
    }
}
