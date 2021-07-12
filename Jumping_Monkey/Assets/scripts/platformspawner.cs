using UnityEngine;

public class platformspawner : MonoBehaviour
{
    public static platformspawner instance;

    [SerializeField]
    GameObject lp = null, rp = null;

    private float leftXmin = -3.33f, leftXmax = -1.4f, rightXmin = 3.331f, rightXmax = 1.4f;
    private float fixedhight = 2.6f;
    private float lasty;

    public int count = 0;
    private int platformspawned;

    [SerializeField]
    private Transform platformparent=null;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    void Start()
    {
        lasty = transform.position.y;
        spawnplatforms();
    }

    public void spawnplatforms()
    {
        Vector2 temp = transform.position;
        GameObject newpf = null;

        for (int i = 0; i < count; ++i)
        {
            temp.y = lasty;

            if(platformspawned%2==0)
            {
                temp.x = Random.Range(leftXmin, leftXmax);
                newpf = Instantiate(rp,temp,Quaternion.identity);
            }
            else
            {
                temp.x = Random.Range(rightXmin, rightXmax);
                newpf = Instantiate(lp, temp, Quaternion.identity);
            }

            newpf.transform.parent = platformparent;
            lasty += fixedhight;
            platformspawned++;
        }

        Invoke("spawnplatforms", 0.2f);
    }

    
}
