

public class PushingProgram : Program
{
    private void Start()
    {
        _player.CanPush = true;
    }

    public override void HandleAbilityDown()
    {
        
    }

    private void OnDestroy()
    {
        _player.CanPush = false;
    }
}
