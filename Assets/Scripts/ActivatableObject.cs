using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ActivatableObject : MonoBehaviour
{
    private bool _isActive = false;
    public bool IsActive
    {
        set { _isActive = value; }
        get { return _isActive; }
    }
}
