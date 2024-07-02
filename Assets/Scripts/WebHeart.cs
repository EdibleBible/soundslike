using UnityEngine;
using UnityEngine.SceneManagement;
using static SO_Events;

public class WebHeart : MonoBehaviour
{
    [Tooltip("SO_CurrentLevel")] public SO_CurrentLevel levelInfo;
    public int playerHP = 300;

    private void OnEnable()
    {
        levelInfo.heartObject = gameObject;
    }

    public void GetHurt(int damage) //Damage currently unused, getting hurt is always 1 now
    {
        playerHP -= 1;
        CallUpdateHP(playerHP);
        if (playerHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(2);
    }
}
