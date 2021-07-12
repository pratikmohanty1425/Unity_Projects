using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WOOD : MonoBehaviour
{
    public float speed = 3;

    public Text score;
    private int cnt = 0;
    void Update()
    {
        transform.Rotate(0, speed, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KNIFE")
        {
            cnt++;
            score.text = cnt.ToString();
        }
    }
}
