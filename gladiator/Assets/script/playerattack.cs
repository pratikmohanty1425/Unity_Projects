using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    public GameObject attackpoint;

    private sound sfx;

    private void Awake()
    {
        sfx = GetComponentInChildren<sound>();
    }

    void Update()
    {
        int i = Random.Range(1, 4);
        if (Input.GetMouseButtonDown(0))
        {
            animations.instance.attack(i);
            if (i == 1)
            {
                sfx.at1();
            }
            else if (i == 2)
            {
                sfx.at2();
            }
            else if (i == 3)
            {
                sfx.at3();
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animations.instance.defend(true);
            playershield.instance.activateshield(true);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            animations.instance.defend(false);
            animations.instance.unfreezanim();
            playershield.instance.activateshield(false);
        }
    }
    void activateaatackpoint()
    {
        attackpoint.SetActive(true);
    }
    void deactivateaatackpoint()
    {
        if(attackpoint.activeInHierarchy)
        {
            attackpoint.SetActive(false);
        }
    }
}
