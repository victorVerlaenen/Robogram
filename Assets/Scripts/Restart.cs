
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    const string RESTART = "Restart";
    string GAME_SCENE;

    private void Awake()
    {
        GAME_SCENE = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        if(Input.GetButtonDown(RESTART))
        {
            SceneManager.LoadScene(GAME_SCENE);
        }
    }
}
