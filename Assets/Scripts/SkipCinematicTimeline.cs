using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SkipCinematicTimeline : MonoBehaviour
{
    public PlayableDirector playableDirector; // Obiekt PlayableDirector odtwarzaj�cy cinematic
    public string levelUISceneName = "LevelUI"; // Nazwa sceny UI

    void Start()
    {
        // Sprawdzenie czy PlayableDirector jest przypisany
        if (playableDirector == null)
        {
            playableDirector = GetComponent<PlayableDirector>();
        }

        // Podpi�cie funkcji pod zako�czenie odtwarzania timeline
        playableDirector.stopped += OnCinematicEnd;

        // Ukrycie element�w gry na pocz�tku
        HideLevelUI();
    }

    void Update()
    {
        // Sprawdzenie czy zosta� wci�ni�ty klawisz "X"
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
        // Wy�wietlenie element�w gry po zako�czeniu cinematicu
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