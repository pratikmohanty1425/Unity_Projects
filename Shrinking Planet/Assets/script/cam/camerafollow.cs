using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;
    //private state s=null;

    private Vector3 camoffset;
    public float speed = 5;

    void Start()
    {
        camoffset = new Vector3(0, 120, 0);
        this.transform.position = camoffset;
    }

    void Update()
    {
        if(GameManager.instance.isgameovermenuactive==false)
        {
            followplayerasperstate();
        }
    }

    void followplayerasperstate()
    {
        this.transform.position =Vector3.Slerp(this.transform.position, 2.5f * player.transform.position, 500 * Time.deltaTime);

        Vector3 playerup = (player.transform.position - this.transform.position).normalized;

        Quaternion targetrotation = Quaternion.FromToRotation(this.transform.forward, playerup) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetrotation, 500 * Time.deltaTime);
    }
}
