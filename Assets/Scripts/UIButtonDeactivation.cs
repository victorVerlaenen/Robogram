using UnityEngine;
using UnityEngine.UI;

public class UIButtonDeactivation : MonoBehaviour
{
    [SerializeField] private Button _button = null;

    public void DisableButton()
    {
        if (_button != null)
        {
            _button.interactable = false;
        }
    }
}
