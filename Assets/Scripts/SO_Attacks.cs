using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Enums;

[CreateAssetMenu(fileName = "SO_Attacks", menuName = "ScriptableObjects/Attacks")]

public class SO_Attacks : ScriptableObject
{
    public List<MoveType> attack1 = new();
    public List<MoveType> attack2 = new();
    public List<MoveType> attack3 = new();
    public List<MoveType> attack4 = new();
    public List<MoveType> attack5 = new();
}
