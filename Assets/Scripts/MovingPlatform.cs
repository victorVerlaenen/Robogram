
using UnityEngine;

public class MovingPlatform : ActivatableObject
{
    [SerializeField] private Transform _endPosition = null;
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
            Debug.Log("MovingPlatform: _platform could not be found");
            _platform.transform.position = Vector3.Lerp(_platform.transform.position, _endPosition.position, _moveSpeed * Time.deltaTime);
        }
    }
}
