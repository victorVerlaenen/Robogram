

public class PushingProgram : Program
{
    private void Start()
    {
        _player.CanPush = true;
    }

    public override void HandleAbility()
    {
        
    }

    private void OnDestroy()
    {
        _player.CanPush = false;
    }
}
