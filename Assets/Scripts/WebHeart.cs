using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebHeart : MonoBehaviour
{
    public SO_CurrentLevel levelInfo;
    public int playerHP = 1;

    private void OnEnable()
    {
        levelInfo.heartObject = gameObject;
    }

    public void GetHurt(int damage) //Damage currently unused, getting hurt is always 1 now
    {
        playerHP -= 1;
        if (playerHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("deduwa");
    }
}
