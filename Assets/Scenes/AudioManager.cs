using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip pickupSound; // Drag pickup sound here
    public AudioClip crashSound;  // Drag crash sound here
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPickupSound()
    {
        audioSource.PlayOneShot(pickupSound);
    }

    public void PlayCrashSound()
    {
        audioSource.PlayOneShot(crashSound);
    }

}


