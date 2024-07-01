using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_play : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("PlayGame method called");
        SceneManager.LoadSceneAsync("FINAL SCENE");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void OnButtonClicked()
    {
        Debug.Log("Button clicked");
    }
}
