using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadnewarea : MonoBehaviour
{
    public string lvltoload;
    public string exitpoint;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(lvltoload);
            playermovement.player.startpoint = exitpoint;
        }
    }
}
