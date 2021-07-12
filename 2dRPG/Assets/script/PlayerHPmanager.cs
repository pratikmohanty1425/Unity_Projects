using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPmanager : MonoBehaviour
{
    public static PlayerHPmanager instance;
    public float playerMaxHealth;
    public float playerCurrentHealth;
    public float healthBarLenght;
    public GameObject theDeathPanel = null;

    // Start is called before the first frame update
    void Start()
    {
        MakeInstance();
        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCurrentHealth < 0)
        {
            theDeathPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    public void DmgPlayer(float damageToGive)
    {
        playerCurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth -= playerMaxHealth;
    }
}
