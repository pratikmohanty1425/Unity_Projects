using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputcontrolles : MonoBehaviour
{
    private animcontroller anim;
    private gameplaycontroller gameplay;
    private string playerch;

    private void Awake()
    {
        anim = GetComponent<animcontroller>();
        gameplay = GetComponent<gameplaycontroller>();
    }
    public void getchoise()
    {
        string choisename = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        gamechoises selectedChoise = gamechoises.NONE;
        Debug.Log(choisename);
        switch(choisename)
        {
            case "ROCK":
                selectedChoise = gamechoises.Rock;
                break;
            case "PAPER":
                selectedChoise = gamechoises.Paper;
                break;
            case "SCISSORS":
                selectedChoise = gamechoises.Scissors;
                break;
        }
        Debug.Log(selectedChoise);
        gameplay.setchoise(selectedChoise);
        anim.playermadechoise();
    }
}
