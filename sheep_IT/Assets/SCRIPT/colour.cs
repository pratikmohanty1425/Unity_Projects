using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colour : MonoBehaviour
{
    private Renderer Renderer;

    public static colour instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Renderer = GetComponent<Renderer>();
    }
}
