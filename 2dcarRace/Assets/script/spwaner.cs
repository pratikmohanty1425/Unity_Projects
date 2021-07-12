using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwaner : MonoBehaviour
{
    public GameObject[] enemies;
    float max = 1.94f;
    float min = -1.94f;
    public float delaytimer = 1f;
    public float timer;
    public GameObject over;
    private void Awake()
    {
        over.SetActive(false);
    }
    private void Update()
    {
        if(carmovment.q==0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Vector3 temp = transform.position;
                temp.x = Random.Range(min, max);
                int rand = Random.Range(0, enemies.Length);
                Instantiate(enemies[rand], temp, enemies[rand].transform.rotation);
                timer = delaytimer;
            }
        }
        else
        {
            over.SetActive(true);
        }
    }
}
