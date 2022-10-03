using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingProgram : Program
{
    private static readonly Vector2 _jumpVelocity = new Vector2(0, 1000);

    public override void HandleAbility()
    {
        // Doesn't work
        _player.Movement.DesiredMovementDirection = new Vector2(_player.Movement.DesiredMovementDirection.x, _jumpVelocity.y);
    }
}
