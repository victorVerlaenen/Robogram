
using UnityEngine;
using UnityEngine.UI;

public class SelectionActivation : MonoBehaviour
{
    public void SetActive(bool value)
    {
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
}
