using TMPro;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;
    private TextMeshPro _text = null;
    private Rigidbody2D _rigidBody = null;
    private LineRenderer _lineRenderer = null;
    private bool _forward = false;
    private bool _backwards = false;
    private int _counter = 5;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _forward = true;
        _lineRenderer = GetComponentInChildren<LineRenderer>();
        _text = GetComponentInChildren<TextMeshPro>();

        Invoke(RETURN_TO_ROBOT_METHODNAME, 5);
        if (_text != null)
        {
            Invoke(COUNTDOWN_METHODNAME, 1);
        }
    }

    const string COUNTDOWN_METHODNAME = "CountDown";
    private void CountDown()
    {
        _counter--;
        _text.text = _counter.ToString();
        if (_counter > 0)
        {
            Invoke(COUNTDOWN_METHODNAME, 1);
        }

    }

    const string RETURN_TO_ROBOT_METHODNAME = "ReturnToRobot";
    private void ReturnToRobot()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if(_text == null)
        {
            return;
        }
        _text.gameObject.transform.rotation = Quaternion.identity;
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
    const string INTERACTABLE_LAYER = "Interactable";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer(ENEMY_LAYER))
        {
            _forward = false;
            _rigidBody.velocity = Vector2.zero;
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer(INTERACTABLE_LAYER))
        {
            transform.position = collision.bounds.center;
        }
    }

}
