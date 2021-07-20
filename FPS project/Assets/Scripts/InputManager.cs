using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playercontrols;

    public Vector2 movementInput;
    private float MoveAmount;
    public float verticalinput;
    public float Horizontalinput;

    public static InputManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void OnEnable()
    {
        if (playercontrols == null)
        {
            playercontrols = new PlayerControls();
            playercontrols.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }

        playercontrols.Enable();
    }

    private void OnDisable()
    {
        playercontrols.Disable();
    }

    public void HandleAllInputs()
    {
        handleMovementInput();
    }

    private void handleMovementInput()
    {
        verticalinput = movementInput.y;
        Horizontalinput = movementInput.x;
        MoveAmount = Mathf.Clamp01(Mathf.Abs(Horizontalinput) + Mathf.Abs(verticalinput));
        AnimatorManager.instance.UpdateAnimatorValues(0, MoveAmount);
    }
}
