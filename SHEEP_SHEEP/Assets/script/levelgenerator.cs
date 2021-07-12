using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.VFX;

public class levelgenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject startplatform = null, endplatform = null,
        platform1 = null, platform2 = null, spikeplatform= null;

    private float blockwidht = 0.5f, blockhight = 0.2f;

    [SerializeField]
    private int amounttospawn;
    private int beginamount = 0;

    private Vector3 lastpos;

    private List<GameObject> spawnplatform = new List<GameObject>();

    [SerializeField]
    private GameObject player = null;

    void Awake()
    {
        amounttospawn = Random.Range(0, 300);
        createlevel();
    }

    void createlevel()
    {
        for(int i=beginamount;i<amounttospawn;i++)
        {
            GameObject newpl;
            int chance = Random.Range(0, 2);
            int chance2 = Random.Range(0, 3);
            if (i==0)
            {
                newpl = Instantiate(startplatform);
            }
            else if(i==amounttospawn-1)
            {
                newpl = Instantiate(endplatform);
                newpl.tag = "endplatform";
            }
            else
            {
                if(chance2==0)
                {
                    newpl = Instantiate(spikeplatform);
                }
                else if (chance2 == 2)
                {
                    newpl = Instantiate(platform2);
                }
                else
                {
                    newpl = Instantiate(platform1); 

                }

                
            }
            
            newpl.transform.parent = transform;

            spawnplatform.Add(newpl);

            if(i==0)
            {
                lastpos = newpl.transform.position;
                Vector3 temp = lastpos;
                temp.y += 0.252f;
                Instantiate(player, temp, Quaternion.identity);
                soundmanager.instance.gamestarts();
                continue;
            }

            int left = Random.Range(0, 2);
            if(left==0)
            {
                newpl.transform.position = new Vector3(lastpos.x - blockwidht, lastpos.y + blockhight, lastpos.z);
            }
            else
            {
                newpl.transform.position = new Vector3(lastpos.x, lastpos.y + blockhight, lastpos.z + blockwidht);
            }

            lastpos = newpl.transform.position;

            if(i<25)
            {
                float endpos = newpl.transform.position.y;

                newpl.transform.position = new Vector3(
                                                    newpl.transform.position.x,
                                                newpl.transform.position.y - blockhight * 3,
                                         newpl.transform.position.z);
                newpl.transform.DOLocalMoveY(endpos, 0.3f).SetDelay(i * 0.1f);
            }
        }
    }
}
