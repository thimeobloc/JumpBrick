using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject infoPopup; // Première popup
    public GameObject kinderPlatform; // Deuxième popup

    public void OpenInfoPopup()
    {
        infoPopup.SetActive(true);
    }

    public void CloseInfoPopup()
    {
        infoPopup.SetActive(false);
    }

    public void OpenKinderPlatform()
    {
        kinderPlatform.SetActive(true);
    }

    public void CloseKinderPlatform()
    {
        kinderPlatform.SetActive(false);
    }
}
