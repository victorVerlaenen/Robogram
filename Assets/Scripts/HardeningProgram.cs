using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardeningProgram : Program
{
    private void Start()
    {
        _player.Hardened = true;
    }

    private void OnDestroy()
    {
        _player.Hardened = false;
    }
}
