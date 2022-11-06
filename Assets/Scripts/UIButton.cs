using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField] private Button _button = null;
    private ProgramSelection _selection = null;
    static private int _selectedPrograms = 0;
    private GameObject _q = null;
    private GameObject _e = null;

    private void Awake()
    {
        _selection = FindObjectOfType<ProgramSelection>();
        _q = transform.Find("Q").gameObject;
        _e = transform.Find("E").gameObject;
        _q.SetActive(false);
        _e.SetActive(false);
    }

    public void SetProgram(string program)
    {
        if (_selection != null)
            _selection.SetProgram(program);
    }

    public void DisableButton()
    {
        if (_button != null)
        {
            _button.interactable = false;

        }
    }

    public void DisableControlDisplays()
    {
        if (_q != null)
        {
            _q.SetActive(false);
        }
        if (_e != null)
        {
            _e.SetActive(false);
        }
    }

    public void SetControlDisplay()
    {
        _selectedPrograms++;
        if(_selectedPrograms == 1)
        {
            if(_q != null)
            {
                _q.SetActive(true);
            }
            //Set Q visible
        }
        else if(_selectedPrograms == 2)
        {
            if (_e != null)
            {
                _e.SetActive(true);
            }
            //Set E visible
            _selectedPrograms = 0;
        }
    }
}
