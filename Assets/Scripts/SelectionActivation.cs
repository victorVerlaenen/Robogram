using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionActivation : MonoBehaviour
{
    public void SetActive(bool value)
    {
        foreach (Transform child in transform)
        {
            var button = child.gameObject.GetComponent<Button>();
            if (button != null)
            {
                if (value)
                {
                    child.gameObject.SetActive(value);
                    button.interactable = true;
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
