
using UnityEngine;

public class Laser : ActivatableObject
{
    const string PLAYER_TAG = "Player";

    private RobotCharacter _player = null;
    [SerializeField] private GameObject _laser = null;
    [SerializeField] private BoxCollider2D _collider = null;
    [SerializeField] private GameObject[] _laserVisuals = null;
    private bool _isFaded = false;

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
        if (_player.Hardened == true && _isFaded == false)
        {
            FadeLaser(true);
            _isFaded = true;
        }
        else if(_player.Hardened == false && _isFaded == true)
        {
            FadeLaser(false);
            _isFaded = false;
        }
    }

    private void TurnOff()
    {
        if (_laser == null)
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
        if (_player.Hardened == true)
        {
            return;
        }

        if (collision.gameObject.tag == PLAYER_TAG)
        {
            Destroy(collision.gameObject);
        }
    }

    private void FadeLaser(bool value)
    {
        if (_laserVisuals != null)
        {
            foreach (var laserPart in _laserVisuals)
            {
                var renderer = laserPart.GetComponent<SpriteRenderer>();
                if (renderer != null)
                {
                    renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, value ? 0.05f : 1.0f);
                }
            }
        }
    }
}
