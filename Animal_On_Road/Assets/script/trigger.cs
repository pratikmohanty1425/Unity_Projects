using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trigger : MonoBehaviour
{
    public Text score;
    int cnt = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cnt += 100;
        score.text = cnt.ToString();
        collision.gameObject.transform.position = new Vector2(0, -4.55f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        cnt += 100;
        score.text = cnt.ToString();
        collision.gameObject.transform.position = new Vector2(0, -4.55f);
    }
}
