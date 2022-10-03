using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RobotCharacter : BasicCharacter
{
    const string MOVEMENT = "Movement";
    private const string PRIMARY_ABILITY = "PrimaryAbility";
    private const string SECONDARY_ABILITY = "SecondaryAbility";
    [SerializeField] protected List<GameObject> _programsList = null;

    protected override void Awake()
    {
        base.Awake();

        // Testing
        PrimaryProgram = Instantiate(_programsList.SingleOrDefault(obj => obj.name == "PushingProgram"), Vector3.zero, Quaternion.identity).GetComponent<Program>();
        PrimaryProgram.Initialize();
    }

    private void Update()
    {
        HandleMovementInput();
    }

    private void LateUpdate()
    {
        HandleAbilityInput();
    }

    private void HandleAbilityInput()
    {
        if (PrimaryProgram != null && Input.GetButtonDown(PRIMARY_ABILITY))
        {
            PrimaryProgram.HandleAbility();
        }

        if (SecondaryProgram != null && Input.GetButtonDown(SECONDARY_ABILITY))
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
