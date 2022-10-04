using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1.0f;
    private Rigidbody2D _rigidbody;
    private static readonly Vector2 _jumpVelocity = new Vector2(0, 10);

    private Vector2 _desiredMovementDirection = Vector2.zero;
    public Vector2 DesiredMovementDirection
    {
        get { return _desiredMovementDirection; }
        set { _desiredMovementDirection = value; }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var movement = _desiredMovementDirection.normalized;
        movement *= _movementSpeed;

        var initialVelocity = _rigidbody.velocity;
        _rigidbody.velocity = new Vector2(movement.x, initialVelocity.y);
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpVelocity.y);
    }
}
