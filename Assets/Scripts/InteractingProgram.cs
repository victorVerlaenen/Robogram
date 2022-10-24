
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
