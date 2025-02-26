using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class buttonoptioncréedit : MonoBehaviour
{
    public void OptionCrédit()
    {
        SceneManager.LoadScene("setting");
        Debug.Log("option button pressed");
    }
    
}
