using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_CurrentLevel", menuName = "ScriptableObjects/CurrentLevelData")]

public class SO_CurrentLevel : ScriptableObject
{
    public GameObject heartObject;
    public List<GameObject> enemiesInLevel = new();
    public float levelTime;

}
