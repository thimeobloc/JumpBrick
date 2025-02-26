using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void GoToHome()
    {
        SceneManager.LoadScene("home");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
