using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingProgram : Program
{
   private bool _interacted = false;
    public bool Interacted
    {
        get { return _interacted; }
        set { _interacted = value; }
    }

    public override void HandleAbility()
    {
        _interacted = true;
    }
}
