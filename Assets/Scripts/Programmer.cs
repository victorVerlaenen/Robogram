
using UnityEngine;
using UnityEngine.SceneManagement;

public class Programmer : MonoBehaviour
{
    private MovementBehaviour _movement = null;

    private void Awake()
    {
        _movement = GetComponent<MovementBehaviour>();
    }

    public void EndLevel()
    {
        Invoke(NEXT_LEVEL_METHODNAME, 5);
        if(_movement != null )
        {
            _movement.DesiredMovementDirection = Vector2.right;
        }
    }

    const string NEXT_LEVEL_METHODNAME = "NextLevel";
    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
