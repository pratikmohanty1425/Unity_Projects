using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIinterface : MonoBehaviour
{
    public Transform canvas;
    public Slider playerhealth;
    public Text playername;
    public character player;
    public GameObject framesMenu;

    public virtual void Awake()
    {
        framesMenu.SetActive(false);
    }

    private void Start()
    {
        playername.text = player.chname;
    }

    // Update is called once per frame
    void Update()
    {
        playerhealth.maxValue = player.maxhealth;
        playerhealth.value = player.health;
        checkcancle();
    }

    void checkcancle()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Debug.Log("esc");
            if(framesMenu.activeInHierarchy)
            {
                framesMenu.SetActive(false);
            }
            else
            {
                framesMenu.SetActive(true);
            }
        }
    }

    public void clickreturn()
    {
        framesMenu.SetActive(false);
    }

    public void clickquit()
    {
        SceneManager.LoadScene("menu");
    }
}
