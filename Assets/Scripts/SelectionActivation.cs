using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionActivation : MonoBehaviour
{
    public void SetActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
}
