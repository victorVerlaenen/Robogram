using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingProgram : Program
{

    public override void HandleAbility()
    {
        // Debug
        _player.Movement.Jump();
    }

    private void OnEnable()
    {
        _player.CanPush = true;
    }

    private void OnDisable()
    {
        _player.CanPush = false;
    }
}
