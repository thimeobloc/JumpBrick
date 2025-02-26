using UnityEngine;
using UnityEngine.SceneManagement;

public class backbutton : MonoBehaviour
{
    public void Back() {
        SceneManager.LoadScene("deb");
        Debug.Log("back Button Press");
    }
    
}

