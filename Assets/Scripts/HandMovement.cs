using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;
    private Rigidbody2D _rigidBody = null;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_rigidBody != null)
        {
            _rigidBody.velocity = transform.up * _moveSpeed;
        }
    }
    
}
