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

    private bool _canPush = true;
    public bool CanPush
    {
        set { _canPush = value; }
        get { return _canPush; }
    }

    protected override void Awake()
    {
        base.Awake();

        // Testing
        var pushing = _programsList.SingleOrDefault(obj => obj.name == "PushingProgram");
        if (pushing != null)
        {
            PrimaryProgram = Instantiate(pushing, Vector3.zero, Quaternion.identity).GetComponent<Program>();
            if (PrimaryProgram != null)
            {
                PrimaryProgram.Initialize();
            }
        }
        var extending = _programsList.SingleOrDefault(obj => obj.name == "ExtendingProgram");
        if (extending != null)
        {
            SecondaryProgram = Instantiate(extending, Vector3.zero, Quaternion.identity).GetComponent<Program>();
            if (SecondaryProgram != null)
            {
                SecondaryProgram.Initialize();
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
