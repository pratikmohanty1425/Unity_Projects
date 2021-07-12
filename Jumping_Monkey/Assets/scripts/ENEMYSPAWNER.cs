using UnityEngine;

public class ENEMYSPAWNER : MonoBehaviour
{
    public GameObject enemy;
    public SpriteRenderer sp;
    private float minx=-1.9f,maxx=1.9f;

    void Start()
    {
        enemies();
    }

    void enemies()
    {
        Vector3 temp = transform.position;
        temp.z = 0;
        temp.x += Random.Range(minx, maxx);

        if (Random.Range(0,20)<3)
        {
            if(temp.x<0)
            {
                sp.flipX=true;
                Instantiate(enemy, temp, Quaternion.identity);
            }
            else
            {
                Instantiate(enemy, temp, Quaternion.identity);
            }
        }

        Invoke("enemies", 0.5f);
    }
}
