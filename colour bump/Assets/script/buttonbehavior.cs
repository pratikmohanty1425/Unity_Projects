using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonbehavior : MonoBehaviour
{

    public void changescene(int sceneindex)
    {
        Debug.Log("PRSSSED");
        StartCoroutine(START(sceneindex));
    }
    IEnumerator START(int IN)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(IN);
    }
    public void resets()
    {
        trigger.Reset = true;
        Debug.Log(trigger.getsceneindex().ToString());

    }
    public void exit()
    {
        Application.Quit();
    }
}
