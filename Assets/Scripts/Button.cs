using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject _connectedObject = null;
    private ActivatableObject _activableObject = null;
    private bool _playerOnButton = false;

    private void Awake()
    {
        _activableObject = _connectedObject.GetComponentInChildren<ActivatableObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //_activableObject.IsActive = true;
        _playerOnButton = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerOnButton = false;
    }
}
