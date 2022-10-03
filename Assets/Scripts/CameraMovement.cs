using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _cameraRadius = 2.5f;
    [SerializeField] private GameObject _player;
    private Rigidbody2D _playerRigidBody;

    private Vector3 _neutralPosition = Vector3.zero;
    private Vector3 _targetPosition = Vector3.zero;
    private const float _haltMargin = 0.01f;

    private void Awake()
    {
        if (_player == null)
        { 
            return;
        }

        _playerRigidBody = _player.GetComponent<Rigidbody2D>();
        _neutralPosition = transform.position;

        Debug.Log("neutral position: " + _neutralPosition);
    }

    private void Update()
    {
        if (_playerRigidBody.velocity.magnitude < _haltMargin)
        {
            _targetPosition = _neutralPosition;
        }
        else
        {
            Vector2 _cameraDesiredMovement = _playerRigidBody.velocity.normalized * _cameraRadius;
            _targetPosition = new Vector3(_neutralPosition.x + _cameraDesiredMovement.x, _neutralPosition.y + _cameraDesiredMovement.y, _neutralPosition.z);
        }

        if (Vector2.Distance(transform.position, _targetPosition) >= _haltMargin)
        {
            transform.position = Vector3.Lerp(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
    }
}
