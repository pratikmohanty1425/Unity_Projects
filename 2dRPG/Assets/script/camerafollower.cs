using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollower : MonoBehaviour
{
    public GameObject followplayer;
    private Vector3 playerpos;
    public float movespeed;

    private static bool cameraexists;

    public static camerafollower cam;

    private void Awake()
    {
        if(cam==null)
        {
            cam = this;
        }
    }

    void Start()
    {
        if(!cameraexists)
        {
            cameraexists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        playerpos = new Vector3(followplayer.transform.position.x,
            followplayer.transform.position.y,
            -10);

        transform.position = Vector3.Lerp(transform.position,
            playerpos,movespeed * Time.deltaTime);

    }
}
