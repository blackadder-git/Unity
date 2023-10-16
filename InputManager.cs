using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // reference to the c# class in assets/input
    private PlayerInput playerInput;

    // reference to roaming actions in PlayerInput
    private PlayerInput.RoamActions roam;

    // reference to PlayerMotor
    private PlayerMotor motor;

    // reference to PlayerLook
    private PlayerLook look;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        roam = playerInput.Roam;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        // register a callback to call motor.Jump() anytime a jump is performed
        roam.Jump.performed += ctx => motor.Jump();
    }

    // process player movement
    void FixedUpdate()
    {
        // process player movement with value from movement action
        motor.ProcessMove(roam.Walk.ReadValue<Vector2>());   
    }

    // process player look
    void LateUpdate()
    {
        // process player movement with value from movement action
        look.ProcessLook(roam.Look.ReadValue<Vector2>());
    }

    // needed before the class can be used
    private void OnEnable() 
    {
        roam.Enable();
    }

    // needed before the class can be used
    private void OnDisable()
    {
        roam.Disable();
    }
}