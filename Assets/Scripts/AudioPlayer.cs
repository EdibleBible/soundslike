using UnityEngine;

// Used to play one time audio like when the player moves or an attack happens
public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip clip) // Called by other scripts
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
