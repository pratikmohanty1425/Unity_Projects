using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum combostate
{
    NONE,
    PUNCH1,
    PUNCH2,
    PUNCH3,
    KICK1,
    KICK2
}

public class playerattack : MonoBehaviour
{
    private playeranimation anim;
    private bool activatetimertoreset;

    private float defaultcombotimer = 0.4f;
    private float currentcombotimer;

    private combostate currentcombostate;

    private void Awake()
    {
        anim = GetComponentInChildren<playeranimation>();
    }

    private void Start()
    {
        currentcombotimer = defaultcombotimer;
        currentcombostate = combostate.NONE;
    }

    void Update()
    {
        comboattack();
        Resetcombostate();
    }

    void comboattack()
    {
        if (Input.GetKeyDown(KeyCode.Q)|| Input.GetMouseButtonDown(0))
        {
            if(currentcombostate==combostate.PUNCH3|| currentcombostate == combostate.KICK1 || currentcombostate == combostate.KICK2)
            {
                return;
            }

            currentcombostate++;
            activatetimertoreset = true;
            currentcombotimer = defaultcombotimer;

            if(currentcombostate==combostate.PUNCH1)
            {
                anim.punch1();
            }
            if (currentcombostate == combostate.PUNCH2)
            {
                anim.punch2();
            }
            if (currentcombostate == combostate.PUNCH3)
            { 
                anim.punch3();
            }
            
        }
        if (Input.GetKeyDown(KeyCode.E)|| Input.GetMouseButtonDown(1))
        {
            if (currentcombostate == combostate.PUNCH3 || currentcombostate == combostate.KICK2)
            {
                return;
            }
            if (currentcombostate == combostate.NONE || currentcombostate == combostate.PUNCH1 || currentcombostate == combostate.PUNCH2)
            {
                currentcombostate = combostate.KICK1;
            }
            else if (currentcombostate == combostate.KICK1)
            {
                currentcombostate++;
            }

            activatetimertoreset = true;
            currentcombotimer = defaultcombotimer;
            if (currentcombostate == combostate.KICK1)
            {
                anim.kick1();
            }
            if (currentcombostate == combostate.KICK2)
            {
                anim.kick2();
            }

        }
    }

    void Resetcombostate()
    {
        if (activatetimertoreset)
        {
            currentcombotimer -= Time.deltaTime;
            if(currentcombotimer<=0)
            {
                currentcombostate = combostate.NONE;
                currentcombotimer = defaultcombotimer;
                activatetimertoreset = false;
            }
        }
    }

}
