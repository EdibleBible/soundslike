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
            // Dodajemy metodę OnPlayableDirectorStopped do eventu stopped PlayableDirector
            playableDirector.stopped += OnPlayableDirectorStopped;
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector director)
    {
        // Zatrzymujemy odtwarzanie audio, gdy PlayableDirector się zatrzyma
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    void OnDestroy()
    {
        // Usuwamy metodę z eventu, aby uniknąć błędów, gdy obiekt zostanie zniszczony
        if (playableDirector != null)
        {
            playableDirector.stopped -= OnPlayableDirectorStopped;
        }
    }

    // Opcjonalnie, możemy dodać metodę, aby uruchomić Timeline i audio razem
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
