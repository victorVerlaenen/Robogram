using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccesPoint : MonoBehaviour
{
    const string PLAYER_TAG = "Player";
    const string PROGRAM_CHANGE = "SetPrograms";

    private bool _canChangePrograms = false;
    private bool _used = false;
    private bool _activated = false;

    private SelectionActivation _selectionMenu = null;

    [SerializeField] SpriteRenderer _screen = null;

    private void Start()
    {
        _selectionMenu = FindObjectOfType<SelectionActivation>();
    }

    private void Update()
    {
        if (_canChangePrograms == true
            && _used == false)
        {
            if (Input.GetButtonDown(PROGRAM_CHANGE))
            {
                _selectionMenu.SetActive(true);
                DestroyCurrentPrograms();
                _activated = true;
            }
        }
    }

    private void DestroyCurrentPrograms()
    {
        var currentPrograms = FindObjectsOfType<Program>();
        foreach (Program program in currentPrograms)
        {
            Destroy(program.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_used == true)
        {
            return;
        }

        if (collision.gameObject.tag == PLAYER_TAG)
        {
            _canChangePrograms = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_used == true)
        {
            return;
        }
        if (_activated == true)
        {
            _used = true;
            if(_screen != null)
            {
                _screen.color = Color.black;
            }

            if (collision.gameObject.tag == PLAYER_TAG)
            {
                _canChangePrograms = false;
                _selectionMenu.SetActive(false);
            }
        }
    }
}
