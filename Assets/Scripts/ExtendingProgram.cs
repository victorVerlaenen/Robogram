using UnityEngine;

public class ExtendingProgram : Program
{
    [SerializeField] GameObject _handTemplate = null;
    private Camera _camera = null;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public override void HandleAbility()
    {
        if (_handTemplate != null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            var direction = (_camera.ScreenToWorldPoint(mousePos) - _player.transform.position).normalized;
            var hand = Instantiate(_handTemplate, _player.transform.position, Quaternion.identity);

            if(hand != null)
            {
                hand.transform.up = direction;
                hand.transform.forward = Vector3.forward;
            }
        }
    }
}
