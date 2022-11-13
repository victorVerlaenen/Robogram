
using UnityEngine;
using UnityEngine.UI;

public class SelectionActivation : MonoBehaviour
{
    private Image _panel = null;
    [SerializeField] private GameObject[] _usableButtons = null;
    private Vector2 _startButtonPosition = new Vector2(125, -50);
    private Vector2 _incrementButtonPosition = new Vector2(200, 0);
    private Vector2 _nextButtonPosition = Vector2.zero;

    private void Awake()
    {
        _nextButtonPosition = _startButtonPosition;
        _panel = GetComponent<Image>();
        if (_panel != null)
            _panel.enabled = false;

        if(_usableButtons != null)
        {
            foreach(var button in _usableButtons)
            {
                var obj = Instantiate(button, _nextButtonPosition, Quaternion.identity);
                _nextButtonPosition += _incrementButtonPosition;
                obj.transform.SetParent(transform, false);
            }
        }
    }

    public void SetActive(bool value)
    {
        if (value)
            Pause();
        else
            Resume();

        if (_panel != null)
            _panel.enabled = value;
        foreach (Transform child in transform)
        {
            var button = child.gameObject.GetComponent<Button>();
            var UIButton = child.gameObject.GetComponent<UIButton>();
            if (button != null && UIButton != null)
            {
                if (value)
                {
                    child.gameObject.SetActive(value);
                    button.interactable = true;
                    UIButton.DisableControlDisplays();
                }
                else
                {
                    if (button.interactable == true)
                    {
                        child.gameObject.SetActive(value);
                    }
                }
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0.0f;
    }

    void Resume()
    {
        Time.timeScale = 1.0f;
    }
}
