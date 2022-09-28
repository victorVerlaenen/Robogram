using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1.0f;

    private Rigidbody2D _rigidbody;

    private Vector2 _desiredMovementDirection = Vector2.zero;
    public Vector2 DesiredMovementDirection
    {
        get { return _desiredMovementDirection; }
        set { _desiredMovementDirection = value; }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 movement = _desiredMovementDirection.normalized;
        movement *= _movementSpeed;

        _rigidbody.velocity = movement;
    }
}
