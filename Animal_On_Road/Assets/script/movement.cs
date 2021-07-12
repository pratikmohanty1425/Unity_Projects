using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            rb.MovePosition(rb.position + Vector2.up*.5f);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            rb.MovePosition(rb.position + Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.MovePosition(rb.position + Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.MovePosition(rb.position + Vector2.right);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="car")
        {
            Destroy(gameObject);

        }
    }
}
