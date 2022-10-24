using UnityEngine;

public class BasicCharacter : MonoBehaviour
{
    protected MovementBehaviour _movementBehaviour;
    private Program[] _programs = {null, null};

    public MovementBehaviour Movement
    {
        get { return _movementBehaviour; }
    }

    protected Program PrimaryProgram
    {
        get { return _programs[0]; }
        set { _programs[0] = value; }
    }

    protected Program SecondaryProgram
    {
        get { return _programs[1]; }
        set { _programs[1] = value; }
    }

    protected virtual void Awake()
    {
        _movementBehaviour = GetComponent<MovementBehaviour>();
    }
}
