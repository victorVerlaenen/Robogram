
using UnityEngine;

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
            _player.SetPrograms(_primarySelected, null);
        }
        else
        {
            _player.SetPrograms(null, program);
            _primarySelected = string.Empty;
            _selectionMenu.SetActive(false);
            _currentAccesPoint.Deactivate();
        }
    }
}
