using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="box1")
        {
            Debug.Log("restart");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

}
