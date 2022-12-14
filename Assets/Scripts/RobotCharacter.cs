
using System;
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
        FlipPlayerIfNeeded();
    }

    private void FlipPlayerIfNeeded()
    {
        float inputMovement = Input.GetAxis(MOVEMENT);

        if(inputMovement > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if(inputMovement < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void LateUpdate()
    {
        HandleAbilityInput();
    }

    private void HandleAbilityInput()
    {
        if (PrimaryProgram != null && Input.GetButtonDown(PRIMARY_ABILITY))
        {
            PrimaryProgram.HandleAbilityDown();
        }
        if (PrimaryProgram != null && Input.GetButtonUp(PRIMARY_ABILITY))
        {
            PrimaryProgram.HandleAbilityUp();
        }
        if (PrimaryProgram != null && Input.GetButton(PRIMARY_ABILITY))
        {
            PrimaryProgram.HandleAbilityPressed();
        }

        if (SecondaryProgram != null && Input.GetButtonDown(SECONDARY_ABILITY))
        {
            SecondaryProgram.HandleAbilityDown();
        }
        if (SecondaryProgram != null && Input.GetButtonUp(SECONDARY_ABILITY))
        {
            SecondaryProgram.HandleAbilityUp();
        }
        if (SecondaryProgram != null && Input.GetButton(SECONDARY_ABILITY))
        {
            SecondaryProgram.HandleAbilityPressed();
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
