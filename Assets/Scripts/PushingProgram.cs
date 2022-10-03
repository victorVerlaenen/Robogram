using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingProgram : Program
{
    private static readonly Vector2 _jumpVelocity = new Vector2(0, 100);

    public override void HandleAbility()
    {
        Debug.Log("Jump");
    }
}
