using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_CurrentLevel", menuName = "ScriptableObjects/CurrentLevelData")]

public class SO_CurrentLevel : ScriptableObject
{
    [Tooltip("Central web joint")] public GameObject heartObject;
    [HideInInspector] public List<GameObject> enemiesInLevel = new();
    public float levelTime; // Unused I think?
}
