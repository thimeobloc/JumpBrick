using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditbutton : MonoBehaviour
{
    public void Craidit()
    {
        SceneManager.LoadScene("Crédits");
        Debug.Log("button craidit pressed");
    }
}
