using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PushBlock : MonoBehaviour
{
    const string PLAYER_TAG = "Player";
    private Rigidbody2D _rigidBody = null;
    private RobotCharacter _player = null;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<RobotCharacter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_player == null)
        {
            return;
        }
        if (collision.gameObject.tag == PLAYER_TAG)
        {
            if (_player.CanPush)
            {
                SetMoveable();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == PLAYER_TAG)
        {
            SetMoveable(false);
        }
    }

    private void SetMoveable(bool value = true)
    {
        if(value == true)
        {
            _rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            _rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
