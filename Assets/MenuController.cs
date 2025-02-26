using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    
    public GameObject menu;
    public GameObject menu2;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
    }

    public void Settings()
    {
        menu.SetActive(false);  
        menu2.SetActive(true);
    }

    public void Back()
    {

        menu.SetActive(true);
        menu2.SetActive(false);
    }
}
