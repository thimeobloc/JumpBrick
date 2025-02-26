using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class closePOPUP : MonoBehaviour
{

  
  public GameObject settingsWindow ;
  
    public void SettingsButton(){
      settingsWindow.SetActive(true);
    }

    public void CloseSettingsMenu(){
      settingsWindow.SetActive(false);
  }
}
