using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcam : MonoBehaviour
{
    //private Transform player;

    //private float damping = 2;
    //private float height = 10;

    private Vector3 offset;

    public bool canfollow;

    public GameObject[] bgs;

    private void Awake()
    {
        int ch = Random.Range(0, bgs.Length);
        bgs[ch].SetActive(true);
        canfollow = true;
    }

    private void Start()
    {
        offset = transform.position - playermovment.instance.transform.position;
    }

    private void Update()
    {
        if(canfollow)
        {
            transform.position = Vector3.Lerp(transform.position,
            new Vector3(playermovment.instance.transform.position.x + offset.x,
            playermovment.instance.transform.position.y + offset.y,
            playermovment.instance.transform.position.z + offset.z),
            Time.deltaTime * 2);
        }
    }

}
