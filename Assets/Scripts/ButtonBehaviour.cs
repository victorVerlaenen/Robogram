using UnityEditor;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _connectedObject = null;
    private ActivatableObject _activableObject = null;
    private RobotCharacter _player = null;
    const string PLAYER_TAG = "Player";

    private void Awake()
    {
        _player = FindObjectOfType<RobotCharacter>();
    }

    private void Start()
    {
        _activableObject = _connectedObject.GetComponent<ActivatableObject>();
    }

    private void Update()
    {
       
    }

    private void LateUpdate()
    {
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

    private void OnDrawGizmos()
    {
        if (_activableObject.IsActive == true)
        {
            Gizmos.DrawSphere(_activableObject.transform.position, .5f);
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
