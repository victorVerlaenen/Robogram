using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingProgram : Program
{
    private void Start()
    {
        _player.CanPush = true;
    }

    public override void HandleAbility()
    {
        // Debug
        _player.Movement.Jump();
    }

    
}
