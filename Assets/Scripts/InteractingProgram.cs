using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingProgram : Program
{
    public override void HandleAbility()
    {
        if (_player.CanInteract == true)
        {
            _player.Interacted = true;
        }
    }
}
