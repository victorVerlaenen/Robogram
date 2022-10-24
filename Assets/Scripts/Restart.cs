
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    const string RESTART = "Restart";
    const string GAME_SCENE = "GameScene";
    private void Update()
    {
        if(Input.GetButtonDown(RESTART))
        {
            SceneManager.LoadScene(GAME_SCENE);
        }
    }
}
