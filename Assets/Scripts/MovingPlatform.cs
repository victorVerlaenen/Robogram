using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    enum MovementDirection
    {
        Up,
        Down,
        Left,
        Right
    }
    [SerializeField] private MovementDirection _movementDirection = MovementDirection.Up;
    [SerializeField] private Transform _endPosition = null;

    private float _moveSpeed = 1.0f;

    private bool _isActive = false;
    public bool IsActive
    {
        set { _isActive = value; }
        get { return _isActive; }
    }

    private void Update()
    {
        if(IsActive)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        transform.position = Vector3.Lerp(transform.position, _endPosition.position, _moveSpeed * Time.deltaTime);
    }
}
