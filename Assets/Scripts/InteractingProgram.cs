using UnityEngine;
public class InteractingProgram : Program
{
    public override void HandleAbilityDown()
    {
        if (_player.CanInteract == true)
        {
            _player.Interacted = true;
        }
    }
}
