using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    public Rigidbody rb;


    void Awake()
    {
        rb.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        anim.SetTrigger("ideltorun");
        if(SCORE.inc%10==0)
        {
            rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime * (SCORE.inc/10+1);

        }
        else
        {
            rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;

        }

    }

    public Transform ray;
    public Animator anim;
    public static int i = 0;

    void Update()
    {
        
        RaycastHit hit;
        if(!Physics.Raycast(ray.position,-transform.up,out hit,Mathf.Infinity))
        {
            Debug.Log("about to fall");
            anim.SetTrigger("isfalling");
        }
        else
        {
            anim.SetTrigger("New Trigger");
        }

        if (transform.position.y < -2)
        {
            set(1);
            SceneManager.LoadScene(2);
        }
    }
    public static int set(int n=0)
    {
        return n;
    }
    //public void Switch()
    //{
    //    walking = !walking;
    //    if(walking)
    //    {
    //        transform.rotation = Quaternion.Euler(0, 45, 0);
    //    }
    //    else
    //    {
    //        transform.rotation = Quaternion.Euler(0, -45, 0);
    //    }
    //}
}
