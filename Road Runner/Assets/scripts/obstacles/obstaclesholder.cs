using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclesholder : MonoBehaviour
{
    public GameObject[] child;

    public float limitaxisx;

    public Vector3 firstpos, secondpos;

    void Update()
    {
        transform.position += new Vector3(-GameplayController.instance.movespeed * Time.deltaTime, 0, 0);
        if (transform.localPosition.x <= limitaxisx)
        {
            GameplayController.instance.obstaclesidalive = false;
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        for(int i=0;i< child.Length; i++)
        {
            child[i].SetActive(true);
        }

        if(Random.value<=0.5f)
        {
            transform.localPosition = firstpos;
        }
        else
        {
            transform.localPosition = secondpos;
        }
    }
}
