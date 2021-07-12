using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("des");
    }
    IEnumerator des()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
