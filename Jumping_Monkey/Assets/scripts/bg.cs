using UnityEngine;

public class bg : MonoBehaviour
{
    private GameObject[] bgs;
    private float height;
    private float highestYpos;

    private void Awake()
    {
        bgs = GameObject.FindGameObjectsWithTag("bg");
    }

    void Start()
    {
        height = bgs[0].GetComponent<Collider2D>().bounds.size.y;
        highestYpos = bgs[0].transform.position.y;

        for (int i = 0; i < bgs.Length; i++)
        {
            if(bgs[i].transform.position.y>highestYpos)
            {
                highestYpos = bgs[i].transform.position.y;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="bg")
        {
            if(collision.transform.position.y>=highestYpos)
            {
                Vector3 temp = collision.transform.position;

                for (int i = 0; i < bgs.Length; i++) 
                {
                    if(!bgs[i].activeInHierarchy)
                    {
                        temp.y += height;
                        bgs[i].transform.position = temp;
                        bgs[i].gameObject.SetActive(true);

                        highestYpos = temp.y;
                    }
                }
            }
        }
    }
}
