using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;
    private Rigidbody2D _rigidBody = null;
    private LineRenderer _lineRenderer = null;
    private bool _forward = false;
    private bool _backwards = false;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _forward = true;
        _lineRenderer = GetComponentInChildren<LineRenderer>();
    }

    private void FixedUpdate()
    {
        if (_rigidBody != null)
        {
            if (_forward == true)
            {
                _rigidBody.velocity = transform.up * _moveSpeed;
            }
            if (_backwards == true)
            {
                _rigidBody.velocity = transform.up * -_moveSpeed;
            }
        }
    }

    const string ENEMY_LAYER = "Enemy";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer(ENEMY_LAYER))
        {
            _forward = false;
            _rigidBody.velocity = Vector2.zero;
        }
    }

}
