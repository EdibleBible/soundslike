using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SkipCinematicTimeline : MonoBehaviour
{
    public PlayableDirector playableDirector; // Obiekt PlayableDirector odtwarzaj¹cy cinematic
    public string levelUISceneName = "LevelUI"; // Nazwa sceny UI

    void Start()
    {
        // Sprawdzenie czy PlayableDirector jest przypisany
        if (playableDirector == null)
        {
            playableDirector = GetComponent<PlayableDirector>();
        }

        // Podpiêcie funkcji pod zakoñczenie odtwarzania timeline
        playableDirector.stopped += OnCinematicEnd;

        // Ukrycie elementów gry na pocz¹tku
        HideLevelUI();
    }

    void Update()
    {
        // Sprawdzenie czy zosta³ wciœniêty klawisz "X"
        if (Input.GetKeyDown(KeyCode.X))
        {
            Skip();
        }
    }

    void Skip()
    {
        // Pomijanie cinematicu
        playableDirector.Stop();
        ShowLevelUI();
    }

    void OnCinematicEnd(PlayableDirector director)
    {
        // Wyœwietlenie elementów gry po zakoñczeniu cinematicu
        ShowLevelUI();
    }

    void HideLevelUI()
    {
        // Deaktywowanie sceny UI
        Scene uiScene = SceneManager.GetSceneByName(levelUISceneName);
        if (uiScene.IsValid())
        {
            foreach (GameObject obj in uiScene.GetRootGameObjects())
            {
                obj.SetActive(false);
            }
        }
    }

    void ShowLevelUI()
    {
        // Aktywowanie sceny UI
        Scene uiScene = SceneManager.GetSceneByName(levelUISceneName);
        if (uiScene.IsValid())
        {
            foreach (GameObject obj in uiScene.GetRootGameObjects())
            {
                obj.SetActive(true);
            }
        }
    }
}