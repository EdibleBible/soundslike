using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicManager : MonoBehaviour

{
    public PlayableDirector playableDirector;
    public AudioSource audioSource;

    void Start()
    {
        if (playableDirector != null)
        {
            
            playableDirector.stopped += OnPlayableDirectorStopped;
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector director)
    {
        
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    void OnDestroy()
    {
        
        if (playableDirector != null)
        {
            playableDirector.stopped -= OnPlayableDirectorStopped;
        }
    }

    
    public void PlayCinematic()
    {
        if (playableDirector != null)
        {
            playableDirector.Play();
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
