using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class buttonbehaviour : MonoBehaviour
{
    public void movetoscene(int sceneID)
    {

        Debug.Log("Game enter");

        SceneManager.LoadScene(sceneID);
    }

    public void exit()
    {
        Application.Quit();

        Debug.Log("Game is exiting");
    }
}
     