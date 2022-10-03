using UnityEngine;

public class Program : MonoBehaviour
{
    protected BasicCharacter _player = null;

    public void Initialize()
    {
        _player = FindObjectOfType<BasicCharacter>();
        if (_player == null)
        {
            Debug.Log("Player not found!");
        }
    }

    public virtual void HandleAbility()
    {
        
    }
}
