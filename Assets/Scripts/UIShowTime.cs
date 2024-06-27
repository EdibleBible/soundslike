using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIShowTime : MonoBehaviour
{
    public SO_CurrentLevel levelInfo;
    public TMP_Text text;
    public void ShowTime()
    {
        float time = levelInfo.levelTime;
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        text.text = "Time Lasted: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
