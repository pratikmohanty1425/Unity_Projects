using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpManager : MonoBehaviour
{
    public static EnemyHpManager instance;
    public float enemyMaxHealth;
    public float enemyCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        MakeInstance();
        enemyCurrentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    public void DmgEnemy(float DmgToGive)
    {
        enemyCurrentHealth -= DmgToGive;
    }

    public void SetMaxHealt()
    {
        enemyCurrentHealth -= enemyMaxHealth;
    }
}
