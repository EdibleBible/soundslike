using System.Collections.Generic;
using UnityEngine;
using static SO_Enums;

[CreateAssetMenu(fileName = "SO_MoveHistory", menuName = "ScriptableObjects/Moves&JointHistory")]

public class SO_MoveHistory : ScriptableObject
{
    [HideInInspector] public List<GameObject> trailJoints = new();
    [HideInInspector] public List<MoveType> moves = new();
}
