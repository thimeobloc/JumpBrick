using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject infoPopup; // Première popup
    public GameObject kinderPlatform; // Deuxième popup
    public GameObject platformMars; // Popup pour Mars
    public GameObject platformBounty; // Popup pour Bounty

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

    public void OpenPlatformMars()
    {
        platformMars.SetActive(true);
    }

    public void ClosePlatformMars()
    {
        platformMars.SetActive(false);
    }

    public void OpenPlatformBounty()
    {
        platformBounty.SetActive(true);
    }

    public void ClosePlatformBounty()
    {
        platformBounty.SetActive(false);
    }
}
