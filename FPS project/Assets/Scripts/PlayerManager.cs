using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private void Awake()
    {
        
    }

    private void Update()
    {
        InputManager.instance.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        PlayerLocoMotion.instance.HandleAllMovement();
    }
}
