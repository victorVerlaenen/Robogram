using UnityEngine;
using UnityEngine.XR;

public class ExtendingProgram : Program
{
    [SerializeField] GameObject _handTemplate = null;
    private Camera _camera = null;
    private GameObject _hand = null;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public override void HandleAbility()
    {
        if (_handTemplate != null)
        {
            if (_hand == null)
            {
                _hand = Instantiate(_handTemplate, _player.Socket.position, Quaternion.identity);

                if (_hand != null)
                {
                    LookAtMouse(_hand);
                }
            }
            else
            {
                Destroy(_hand);
            }
        }
    }

    private void LookAtMouse(GameObject obj)
    {
        Vector3 diff = _camera.ScreenToWorldPoint(Input.mousePosition) - _player.Socket.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        obj.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
