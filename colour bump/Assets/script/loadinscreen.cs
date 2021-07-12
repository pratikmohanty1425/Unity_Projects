using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadinscreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(load());
    }
    IEnumerator load()
    {
        yield return new WaitForSeconds(4);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
    }

}
