using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_play : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1); 
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
