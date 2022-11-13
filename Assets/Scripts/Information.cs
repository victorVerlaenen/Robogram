
using UnityEngine;

public class Information : MonoBehaviour
{
    [SerializeField] private Sprite _displayTexture = null;
    [SerializeField] private GameObject _visuals = null;
    [SerializeField] private GameObject _activatedVisuals = null;
    private SpriteRenderer _spriteRenderer = null;
    private bool _canPress = false;
    [SerializeField] private bool _canBeActivated = false;

    private void Awake()
    {
        if (_visuals == null)
        {
            Debug.Log("_visuals not found");
            return;
        }
        if (_displayTexture == null)
        {
            Debug.Log("_displayTexture not found");
            return;
        }
        _visuals.SetActive(false);
        _spriteRenderer = _visuals.GetComponent<SpriteRenderer>();
        if (_spriteRenderer == null)
        {
            Debug.Log("_spriteRenderer not found");
            return;
        }
        _spriteRenderer.sprite = _displayTexture;
    }

    const string SELECTION_BUTTON = "SetPrograms";
    private void Update()
    {
        if (_activatedVisuals == null || _canBeActivated == false)
        {
            return;
        }
        if (Input.GetButtonDown(SELECTION_BUTTON) && _canPress)
        {
            _activatedVisuals.SetActive(true);
            _visuals.SetActive(false);
        }
    }

    const string PLAYER_TAG = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == PLAYER_TAG)
        {
            _canPress = true;
            _visuals.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == PLAYER_TAG)
        {
            _canPress = false;
            _visuals.SetActive(false);
            _activatedVisuals.SetActive(false);
        }
    }
}
