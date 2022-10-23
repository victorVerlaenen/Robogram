using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _connectedObject = null;
    private ActivatableObject _activableObject = null;
    private RobotCharacter _player = null;
    const string PLAYER_TAG = "Player";

    private void Awake()
    {
        _activableObject = _connectedObject.GetComponentInChildren<ActivatableObject>();
        _player = FindObjectOfType<RobotCharacter>();
    }

    private void Update()
    {
        if (_player == null)
        {
            return;
        }
        if (_activableObject == null)
        {
            return;
        }
        if (_player.Interacted == true)
        {
            _activableObject.IsActive = true;
            _player.Interacted = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_player == null)
        {
            return;
        }
        if (collision.gameObject.tag == PLAYER_TAG)
        {
            _player.CanInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_player == null)
        {
            return;
        }
        if (collision.gameObject.tag == PLAYER_TAG)
        {
            _player.CanInteract = false;
        }
    }
}
