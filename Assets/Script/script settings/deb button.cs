using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class debbutton : MonoBehaviour
{
    public void Debut() {
        SceneManager.LoadScene("setting");
        Debug.Log("play button pressed");
    }
    
    
}
