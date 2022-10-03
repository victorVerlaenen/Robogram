using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCharacter : BasicCharacter
{
    const string MOVEMENT = "Movement";
    private const string PRIMARY_ABILITY = "PrimaryAbility";
    private const string SECONDARY_ABILITY = "SecondaryAbility";

    private void Start() // Testing purpose
    {
        PrimaryProgram = new PushingProgram();
    }

    private void Update()
    {
        HandleMovementInput();
        HandleAbilityInput();
    }

    private void HandleAbilityInput()
    {
       // if (PrimaryProgram != null && Input.GetAxis(PRIMARY_ABILITY))
        {
            Debug.Log("Primary abil");
            PrimaryProgram.HandleAbility();
        }

        if (SecondaryProgram != null && Input.GetKeyDown(SECONDARY_ABILITY))
        {
            SecondaryProgram.HandleAbility();
        }
    }

    private void HandleMovementInput()
    {
        if (_movementBehaviour == null)
            return;

        // Movement
        float movementAxis = Input.GetAxis(MOVEMENT);
        Vector2 movement = movementAxis * Vector2.right;

        _movementBehaviour.DesiredMovementDirection = movement;
    }
}
