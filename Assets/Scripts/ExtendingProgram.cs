using UnityEngine;

public class ExtendingProgram : Program
{
    [SerializeField] GameObject _handTemplate = null;
    [SerializeField] LayerMask _layerMask;
    private LineRenderer _lineRenderer = null;
    private Camera _camera = null;
    private GameObject _hand = null;

    private void Awake()
    {
        _camera = Camera.main;
        _lineRenderer = GetComponent<LineRenderer>();
        if (_lineRenderer != null)
        {
            _lineRenderer.enabled = false;
        }
    }

    public override void HandleAbilityPressed()
    {
        _lineRenderer.SetPosition(0, _player.Socket.position);
        var hit = Physics2D.Raycast(_player.Socket.position, _camera.ScreenToWorldPoint(Input.mousePosition) - _player.Socket.position, 1000, _layerMask);
        _lineRenderer.SetPosition(1, hit.point);

        float width = 0.2f;
        _lineRenderer.material.mainTextureScale = new Vector2(1f / width, 1.0f);
    }

    public override void HandleAbilityUp()
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
        _lineRenderer.enabled = false;
    }

    public override void HandleAbilityDown()
    {
        if (_hand == null)
            _lineRenderer.enabled = true;
    }

    private void LookAtMouse(GameObject obj)
    {
        Vector3 diff = _camera.ScreenToWorldPoint(Input.mousePosition) - _player.Socket.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        obj.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
