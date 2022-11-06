using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _connectedObject = null;
    [SerializeField] private bool _levelEnding = false;
    private ActivatableObject _activableObject = null;
    private RobotCharacter _player = null;
    private Light2D _light = null; 
    const string PLAYER_TAG = "Player";
    bool _canBeClicked = false;

    private void Awake()
    {
        _player = FindObjectOfType<RobotCharacter>();
        _light = GetComponentInChildren<Light2D>();
        if(_light != null)
        {
            _light.enabled = false;
        }
    }

    private void Start()
    {
        _activableObject = _connectedObject.GetComponent<ActivatableObject>();
    }

    private void LateUpdate()
    {
        if(_canBeClicked == false)
        {
            return;
        }
        if (_player == null)
        {
            Debug.Log("Button: _player could not be found");
            return;
        }
        if (_activableObject == null)
        {
            Debug.Log("Button: _activableObject could not be found");
            return;
        }
        if (_player.Interacted == true)
        {
            _activableObject.IsActive = true;
            _player.Interacted = false;
            if(_levelEnding == true)
            {
                var programmer = FindObjectOfType<Programmer>();
                if(programmer != null)
                {
                    programmer.EndLevel();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_player == null)
        {
            return;
        }
        if(_light == null)
        {
            return;
        }
        if (collision.gameObject.tag == PLAYER_TAG)
        {
            _player.CanInteract = true;
            _canBeClicked = true;
            _light.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_player == null)
        {
            return;
        }
        if (_light == null)
        {
            return;
        }
        if (collision.gameObject.tag == PLAYER_TAG)
        {
            _player.CanInteract = false;
            _canBeClicked = false;
            _light.enabled = false;
        }
    }
}
