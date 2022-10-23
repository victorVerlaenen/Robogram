using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class ProgramSelection : MonoBehaviour
{
    private RobotCharacter _player = null;
    private string _primarySelected = string.Empty;
    private SelectionActivation _selectionMenu = null;

    private AccesPoint _currentAccesPoint = null;
    public AccesPoint CurrentAccesPoint
    {
        set { _currentAccesPoint = value; }
    }

    private void Start()
    {
        _player = FindObjectOfType<RobotCharacter>();
        _selectionMenu = FindObjectOfType<SelectionActivation>();
    }

    public void SetProgram(string program)
    {
        if(_player == null)
        {
            return;
        }

        if (_primarySelected == string.Empty)
        {
            _primarySelected = program;
        }
        else
        {
            _player.SetPrograms(_primarySelected, program);
            _primarySelected = string.Empty;
            _selectionMenu.SetActive(false);
            _currentAccesPoint.Deactivate();
        }
    }
}