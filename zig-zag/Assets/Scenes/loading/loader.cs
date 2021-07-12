using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class loader : MonoBehaviour
{
    public GameObject loadscreen;
    public Slider s;
    public Text t;

    //public void loadlvl(int sceneindex)
    //{
    //    StartCoroutine(loadasyn(sceneindex));
        
    //}
    void Start()
    {
        StartCoroutine(load());
        //StartCoroutine(loadasyn(1));
        new WaitForSeconds(500);
        //SceneManager.LoadScene(1);
    }
    IEnumerator loadasyn(int sceneindex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneindex);

        loadscreen.SetActive(true);

        while(!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            Debug.Log(progress);
            s.value = progress;
            t.text = Convert.ToInt32( progress * 100f) + "%";
            
            yield return null;
            //yield return null;
        }
    }
    public IEnumerator load()
    {
        Debug.Log("loding");
        yield return new WaitForSeconds(1);
        StartCoroutine(loadasyn(1));
    }
}
