using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject spikes;
    public GameObject[] movingplatform;
    public GameObject breakableplatform;
    public GameObject stars;
    public GameObject[] enemy;

    public float sptimer = 2;
    private float currentptimer;
    private int pcount;
    public float minx =-1.38f, maxx = 1.38f;

    void Start()
    {
        currentptimer = sptimer;
    }

    void Update()
    {
        spawnplatform();
    }

    void spawnplatform()
    {
        currentptimer += Time.deltaTime;
        if(currentptimer>=sptimer)
        {
            pcount++;
            Vector2 temp = transform.position;
            temp.x = Random.Range(minx, maxx);

            GameObject newpf = null;
            if(pcount<2)
            {
                newpf = Instantiate(platform, temp, Quaternion.identity);
            }
            else if(pcount==2)
            {
                if(Random.Range(0,2)>0)
                {
                    newpf = Instantiate(platform, temp, Quaternion.identity);
                }
                else
                {
                    newpf = Instantiate(movingplatform[Random.Range(0,movingplatform.Length)], temp, Quaternion.identity);
                }
            }
            else if(pcount==3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newpf = Instantiate(platform, temp, Quaternion.identity);
                }
                else
                {
                    newpf = Instantiate(spikes, temp, Quaternion.identity);
                }
            }
            else if (pcount == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newpf = Instantiate(platform, temp, Quaternion.identity);
                }
                else
                {
                    newpf = Instantiate(breakableplatform, temp, Quaternion.identity);
                }
                pcount = 0;
            }

            if (Random.Range(0, 2) == 0 && pcount != 3)
            {
                Vector2 t = temp;
                t.y += 0.7f;
                newpf = Instantiate(stars, t, Quaternion.identity);
            }
            if (Random.Range(0, 6) == 0 && pcount != 3)
            {
                Vector2 t = temp;
                t.y += 0.7f;
                t.x += Random.Range(-0.7f, 0.7f);
                newpf = Instantiate(enemy[Random.Range(0,enemy.Length)], t, Quaternion.identity);
            }

            newpf.transform.parent = transform;
            currentptimer = 0;
        }
        
    }
}
