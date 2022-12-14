using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AccesPoint : MonoBehaviour
{
    const string PLAYER_TAG = "Player";
    const string PROGRAM_CHANGE = "SetPrograms";

    private bool _canChangePrograms = false;
    private bool _used = false;
    private bool _activated = false;

    private SelectionActivation _selectionMenu = null;
    private BoxCollider2D _collider = null;
    private ProgramSelection _programSelection = null;
    private AccesPoint _thisAccesPoint = null;

    private Animator _animator = null;

    private Light2D _light = null;

    private void Start()
    {
        _selectionMenu = FindObjectOfType<SelectionActivation>();
        _collider = GetComponent<BoxCollider2D>();
        _programSelection = FindObjectOfType<ProgramSelection>();
        _thisAccesPoint = GetComponent<AccesPoint>();
        _animator = GetComponentInChildren<Animator>();
        _light = GetComponentInChildren<Light2D>();
        if(_light != null)
        {
            _light.enabled = false;
        }
    }

    private void Update()
    {
        if (_thisAccesPoint == null)
        {
            return;
        }

        if (_canChangePrograms == true
            && _used == false)
        {
            if (Input.GetButtonDown(PROGRAM_CHANGE))
            {
                _selectionMenu.SetActive(true);
                DestroyCurrentPrograms();
                _programSelection.CurrentAccesPoint = _thisAccesPoint;
                _programSelection.ResetSelection();
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
        if (collision.gameObject.tag != PLAYER_TAG)
        {
            return;
        }

        if (_used == true)
        {
            return;
        }

        if(_light != null)
        {
            _light.enabled = true;
        }

        if (collision.gameObject.tag == PLAYER_TAG)
        {
            _canChangePrograms = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != PLAYER_TAG)
        {
            return;
        }

        if (_used == true)
        {
            return;
        }

        if (_light != null)
        {
            _light.enabled = false;
        }

        if (_activated == true)
        {
            if (collision.gameObject.tag == PLAYER_TAG)
            {
                Deactivate();   
            }
        }
    }

    public void Deactivate()
    {
        _used = true;
        if (_animator != null && _collider != null)
        {
            _animator.enabled = false;

            _collider.enabled = false;
        }
        if (_light != null)
        {
            _light.enabled = false;
        }

        _canChangePrograms = false;
        _selectionMenu.SetActive(false);
    }
}
