using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Enums", menuName = "ScriptableObjects/Enums")]

public class SO_Enums : ScriptableObject
{
    public enum MoveType { side, up, down, right, left };
    public enum JointCoords
    {
        Center, A0, A1, A2, A3, A4, A5, A6, A7, B0, B1, B2, B3, B4, B5, B6, B7, C0, C1, C2, C3, C4, C5, C6, C7
    }
}
