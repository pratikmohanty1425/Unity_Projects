using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cars : MonoBehaviour
{
    private Rigidbody2D rb;
    float maxspeed = 6;
    float minspeed = 2.5f;
    float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
        speed = Random.Range(minspeed, maxspeed);
    }
    private void Update()
    {
        Vector2 forward = new Vector2(transform.forward.x, transform.forward.y);
        rb.MovePosition(rb.position + (speed * forward * Time.fixedDeltaTime));

    }
}
