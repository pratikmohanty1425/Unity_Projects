using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{
    public float hookspeed;

    public int scorevalue;

    private void OnDisable()
    {
        gameplaymanager.instance.displayscore(scorevalue);
    }
}
