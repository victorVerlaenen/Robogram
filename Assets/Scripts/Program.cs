using UnityEngine;

public class Program : MonoBehaviour
{
    protected RobotCharacter _player = null;

    public void Initialize()
    {
        _player = FindObjectOfType<RobotCharacter>();
        if (_player == null)
        {
            Debug.Log("Player not found!");
        }
    }

    public virtual void HandleAbilityDown()
    {
        
    }

    public virtual void HandleAbilityUp()
    {

    }

    public virtual void HandleAbilityPressed()
    {

    }
}
