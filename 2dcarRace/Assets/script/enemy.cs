using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed=8;
    void Update()
    {
        Vector3 pos;
        pos = transform.position;
        pos.y -= speed * Time.deltaTime;
        transform.position = pos;
        Destroy(gameObject,4);
            
    }
}
