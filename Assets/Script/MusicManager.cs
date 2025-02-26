using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip musicClip;

    void Start()
    {
        audioSource.clip = musicClip;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
} 