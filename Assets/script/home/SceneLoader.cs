using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainGame"); // Le nom doit correspondre exactement
    }
}
