using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCharacter : BasicCharacter
{
    const string MOVEMENT = "Movement";

    private void Update()
    {
        HandleMovementInput();
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
