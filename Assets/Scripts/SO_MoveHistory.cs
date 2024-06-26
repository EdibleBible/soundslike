using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Enums;

[CreateAssetMenu(fileName = "SO_MoveHistory", menuName = "ScriptableObjects/Moves&JointHistory")]

public class SO_MoveHistory : ScriptableObject
{
    [Tooltip("DON'T EDIT - History of visited joints")] public List<GameObject> trailJoints = new();
    [Tooltip("DON'T EDIT - History of made moves")] public List<MoveType> moves = new();
}
