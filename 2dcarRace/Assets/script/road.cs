using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road : MonoBehaviour
{
    public Renderer r;
    public float speed = 10;
    private Vector2 offset;
    private void Awake()
    {
        r = GetComponent<Renderer>();
    }
    void Update()
    {
        offset = new Vector2(0, speed * Time.time);
        r.material.mainTextureOffset = offset;
    }
}
