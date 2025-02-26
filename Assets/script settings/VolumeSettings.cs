using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class VolumeSettings : MonoBehaviour
{
   public AudioSource audiosource;
   public Slider slider;
   public Text TxtVolume;

   private void Start() => SliderChange();

   public void SliderChange()
   {
      audiosource.volume = slider.value;
      TxtVolume.text ="Volume " + (audiosource.volume * 100).ToString("00") + "%";
      
   }
}
