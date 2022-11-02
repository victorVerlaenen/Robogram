using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helpers;

public class RobotAnimationController : MonoBehaviour
{
    private Vector2 _previousPosition;
    private Animator _animator = null;
    private BoxCollider2D _collider = null;
    [SerializeField] private LayerMask _staticLevelLayer;
    [SerializeField] private LayerMask _dynamicLevelLayer;

    private void Awake()
    {
        _previousPosition = transform.root.position;
        _animator = transform.GetComponent<Animator>();
        _collider = transform.root.gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        HandleMovementAnimation();
    }

    private bool IsPlayerGrounded()
    {
        if(_collider == null)
        {
            return false;
        }
        float extraHeight = 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(_collider.bounds.center, Vector2.down, _collider.bounds.extents.y + extraHeight, _staticLevelLayer | _dynamicLevelLayer);
        return hit.collider != null;
    }

    const string IS_MOVING_PARAMETER = "IsMoving";
    private void HandleMovementAnimation()
    {
        if(_animator == null)
        {
            return;
        }

        _animator.SetBool(IS_MOVING_PARAMETER, (transform.root.position - MathHelper.Vector2ToVector3(_previousPosition)).sqrMagnitude > 0.0001f );
        if(!IsPlayerGrounded())
        {
            if (_animator.enabled == true)
            {
                _animator.enabled = false;
            }
        }
        else 
        {
            if (_animator.enabled == false)
            {
                _animator.enabled = true;
            }
        }
        _previousPosition = transform.root.position;
    }
}
