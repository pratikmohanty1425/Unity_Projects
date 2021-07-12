using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Target FirstRowDuckTargetPrefab = null;

    [SerializeField]
    public Target SecondRowDuckTargetPrefab = null;

    [SerializeField]
    public Target CircleTargetPrefab = null;

    private Queue<Target> FirstRowDuckTargetPool = new Queue<Target>();
    private Queue<Target> SecondRowDuckTargetPool = new Queue<Target>();
    private Queue<Target> CircleTargetPool = new Queue<Target>();

    private float timeBetweenWaves = 1f;
    private float nextTimeForWave = 0.5f;


    private void Update()
    {
        if (Time.timeSinceLevelLoad >= nextTimeForWave)
        {
            SpawnWave();
            nextTimeForWave = Time.timeSinceLevelLoad + timeBetweenWaves;
        }
    }

    private void SpawnWave()
    {
        int waveCount = Random.Range(0, 4);

        for (int i = 0; i < waveCount; i++)
        {
            int row = Random.Range(0, 3) + 1;

            SpawnTarget(row);
        }
    }


    public Target SpawnTarget(int row)
    {
        bool isDuck = GetIsDuck(row);

        Vector3 location = new Vector3((isDuck ? Random.Range(-7f, 7f) : Random.Range(-5f, 5f)), 0, 0);
        Vector3 position = (location.x < 0 ? new Vector3(-10, 0) : new Vector3(10, 0));

        Target target = GetFromPool(row, position);

        return target;
    }

    public Target GetFromPool(int row, Vector3 position)
    {
        Queue<Target> pool = null;

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

        if (pool == null)
            pool = FirstRowDuckTargetPool;

        Target target;

        UnityEngine.Debug.Log(pool.Count);
        if (pool.Count == 0)
        {
            target = Instantiate(GetPrefab(row), position, Quaternion.identity, transform);
            target.IsOut += () => { pool.Enqueue(target); };
        }
        else
        {
            target = pool.Dequeue();
            target.transform.position = position;
            target.gameObject.SetActive(true);
        }

        return target;
    }

    public Target GetPrefab(int row)
    {
        switch (row)
        {
            case 0:
                return FirstRowDuckTargetPrefab;

            case 1:
                return SecondRowDuckTargetPrefab;

            case 2:
                return CircleTargetPrefab;
        }

        return FirstRowDuckTargetPrefab;
    } 

   public bool GetIsDuck(int row)
    {
        return row != 2;
    }
}
