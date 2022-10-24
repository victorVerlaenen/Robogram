
using UnityEngine;

public class Laser : MonoBehaviour
{
    const string PLAYER_TAG = "Player";

    private RobotCharacter _player = null;

    private void Awake()
    {
        _player = FindObjectOfType<RobotCharacter>();
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
