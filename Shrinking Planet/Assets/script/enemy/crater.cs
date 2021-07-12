using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crater : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("destroycrater");
    }

    IEnumerator destroycrater()
    {
        int ran = Random.Range(6, 10);
        yield return new WaitForSeconds(ran);
        Destroy(gameObject);
    }
}
