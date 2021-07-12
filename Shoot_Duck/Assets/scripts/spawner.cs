using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField]
    private targets firstrowduckprefab=null;

    [SerializeField]
    public targets secondrowduckprfab=null;

    [SerializeField]
    public targets circleprefab=null;


    private Queue<targets> FirstRowDuckTargetPool = new Queue<targets>();
    private Queue<targets> SecondRowDuckTargetPool = new Queue<targets>();
    private Queue<targets> CircleTargetPool = new Queue<targets>();

    private float timebtnwave = 1f;
    private float nexttimeforwave = 0.5f;


    private void Update()
    {
        if (Time.timeSinceLevelLoad >= nexttimeforwave)
        {
            spawnwave();
            nexttimeforwave = Time.timeSinceLevelLoad + timebtnwave;
        }
    }

    private void spawnwave()
    {
        int wave = Random.Range(0, 4);
        for (int i = 0; i < wave; i++)
        {
            int row = Random.Range(0, 3) + 1;
            spawntarget(row);
        }
    }

    public targets spawntarget(int row)
    {
        bool isduck = getisduck(row);
        Vector3 loc = new Vector3((isduck ? Random.Range(-7f, 7f) : Random.Range(-5f, 5f)), 0, 0);
        Vector3 pos = (loc.x < 0 ? new Vector3(-10, 0) : new Vector3(10, 0));

        targets targets = getfrompool(row, pos);
        return targets;
    }

    public targets getfrompool(int row, Vector3 pos)
    {
        Queue<targets> pool = null;

        switch (row)
        {
            case 0:
                pool = FirstRowDuckTargetPool;
                break;
            case 1:
                pool = SecondRowDuckTargetPool;
                break;
            case 2:
                pool = CircleTargetPool;
                break;
        }

        if(pool==null)
            pool = FirstRowDuckTargetPool;

        
        targets targets;

        int ran = Random.Range(0, 20);
        if (pool.Count == 0)
        {
            targets = Instantiate(getprefab(row), pos,Quaternion.identity,transform);
            targets.isout += () => { pool.Enqueue(targets); };

        }
        else
        {
            targets = pool.Dequeue();
            targets.transform.position = pos;
            targets.gameObject.SetActive(true);
        }

        return targets;
    }

    public targets getprefab(int row)
    {
        switch (row)
        {
            case 0:
                return firstrowduckprefab;
            case 1:
                return secondrowduckprfab;
            case 2:
                return circleprefab;
        }
        return firstrowduckprefab;
    }
    public bool getisduck(int row)
    {
        return row != 2;
    }
}
