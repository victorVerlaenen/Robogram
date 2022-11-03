using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    [SerializeField] private Sprite _displayTexture = null;
    [SerializeField] private GameObject _visuals = null;
    private SpriteRenderer _spriteRenderer = null;


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
        if(_spriteRenderer == null)
        {
            Debug.Log("_spriteRenderer not found");
            return;
        }
        _spriteRenderer.sprite = _displayTexture;
    }

    const string PLAYER_TAG = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == PLAYER_TAG)
        {
            _visuals.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == PLAYER_TAG)
        {
            _visuals.SetActive(false);
        }
    }
}
