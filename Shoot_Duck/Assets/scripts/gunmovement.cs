using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunmovement : MonoBehaviour
{
    public SpriteRenderer sr = null;
    private Camera cam = null;
    public float offset = 1.5f;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mpos = cam.ScreenToWorldPoint(Input.mousePosition);
        bool flip = mpos.x < 0;
        sr.flipX = flip;
        transform.position = new Vector3(Mathf.Clamp(mpos.x + (flip ? -offset : offset), -8.5f, 8.5f), transform.position.y);

    }
}
