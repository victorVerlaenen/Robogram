
using UnityEngine;

public class Laser : ActivatableObject
{
    const string PLAYER_TAG = "Player";

    private RobotCharacter _player = null;
    [SerializeField] private GameObject _laser = null;
    [SerializeField] private BoxCollider2D _collider = null;

    private void Awake()
    {
        _player = FindObjectOfType<RobotCharacter>();
        
    }

    private void Update()
    {
        if (IsActive == true)
        {
            TurnOff();
        }
    }

    private void TurnOff()
    {
        if(_laser == null)
        {
            return;
        }
        if (_collider == null)
        {
            return;
        }
        _laser.SetActive(false);
        _collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_player == null)
        {
            return;
        }
        if(_player.Hardened == true)
        {
            return;
        }

        if (collision.gameObject.tag == PLAYER_TAG)
        {
            Destroy(collision.gameObject);
        }
    }
}
