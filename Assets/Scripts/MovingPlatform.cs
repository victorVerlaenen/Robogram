
using UnityEngine;

public class MovingPlatform : ActivatableObject
{
    [SerializeField] private Transform _endPosition = null;
    [SerializeField] private LayerMask _blockingLayer;
    [SerializeField] private float _overlapRadius = 0.5f;
    private GameObject _platform = null;

    private float _moveSpeed = 1.0f;

    private void Start()
    {
        _platform = transform.Find("Platform").gameObject;
    }

    private void Update()
    {
        if (IsActive)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        if (_platform != null)
        {
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, _overlapRadius, _blockingLayer);
            if (hitObjects.Length <= 1)
            {
                _platform.transform.position = Vector3.Lerp(_platform.transform.position, _endPosition.position, _moveSpeed * Time.deltaTime);
                Debug.Log("Move");
            }
            else
                IsActive = false;

        }
        else
        {
            Debug.Log("MovingPlatform: _platform could not be found");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _overlapRadius);
    }
}
