using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingProgram : Program
{

    public override void HandleAbility()
    {
        _player.Movement.Jump();
    }
}
