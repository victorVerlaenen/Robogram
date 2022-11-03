using UnityEditor;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _connectedObject = null;
    private ActivatableObject _activableObject = null;
    private RobotCharacter _player = null;
    const string PLAYER_TAG = "Player";
    bool _canBeClicked = false;

    private void Awake()
    {
        _player = FindObjectOfType<RobotCharacter>();
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
            _canBeClicked = true;
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
            _canBeClicked = false;
        }
    }
}
