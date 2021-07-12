using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershield : MonoBehaviour
{
    public static playershield instance;

    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }
    }
    public void activateshield(bool shieldactive)
    {
        health.instance.shieldactive = shieldactive;
    }
}
