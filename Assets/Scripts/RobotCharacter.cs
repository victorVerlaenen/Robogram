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
    [SerializeField] private Transform _socket = null;

    public Transform Socket
    {
        get { return _socket; }
    }

    private bool _hardened = false;
    public bool Hardened
    {
        get { return _hardened; }
        set { _hardened = value; }
    }

    private bool _canInteract = false;
    public bool CanInteract
    {
        get { return _canInteract; }
        set { _canInteract = value; }
    }

    private bool _interacted = false;
    public bool Interacted
    {
        get { return _interacted; }
        set { _interacted = value; }
    }

    private bool _canPush = false;
    public bool CanPush
    {
        set { _canPush = value; }
        get { return _canPush; }
    }

    public void SetPrograms(string primaryProgram, string secondayProgram)
    {
        var secondary = _programsList.SingleOrDefault(obj => obj.name == secondayProgram);
        if (secondary != null)
        {
            SecondaryProgram = Instantiate(secondary, Vector3.zero, Quaternion.identity).GetComponent<Program>();
            if (SecondaryProgram != null)
            {
                SecondaryProgram.Initialize();
            }
        }
        var primary = _programsList.SingleOrDefault(obj => obj.name == primaryProgram);
        if (primary != null)
        {
            PrimaryProgram = Instantiate(primary, Vector3.zero, Quaternion.identity).GetComponent<Program>();
            if (PrimaryProgram != null)
            {
                PrimaryProgram.Initialize();
            }
        }
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
