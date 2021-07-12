using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg : MonoBehaviour
{
    public GameObject[] bgs;

    private void Awake()
    {
        int ch = Random.Range(0, bgs.Length);
        bgs[ch].SetActive(true);
    }
}
