
using UnityEngine;

public class MovingPlatform : ActivatableObject
{
    [SerializeField] private Transform _endPosition = null;

    private float _moveSpeed = 1.0f;

    private void Update()
    {
        if(IsActive)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        transform.position = Vector3.Lerp(transform.position, _endPosition.position, _moveSpeed * Time.deltaTime);
    }
}
