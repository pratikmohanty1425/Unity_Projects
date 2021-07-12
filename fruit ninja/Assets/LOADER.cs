using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LOADER : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(start());
    }
    IEnumerator start()
    {

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(1);
    }
}
