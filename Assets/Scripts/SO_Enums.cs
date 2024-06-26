using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Enums", menuName = "ScriptableObjects/Enums")]

public class SO_Enums : ScriptableObject
{
    public enum MoveType { side, up, down, right, left }; // Side is actually the default "not set" move type

    //To get each joint's outwards direction you need to perform ((int)coord % 8 - 1) - cast enum to int, modulo by 8 to disregard layers & subtract 1 because this enum starts with Center
    public enum JointCoords
    {
        Center, A0, A1, A2, A3, A4, A5, A6, A7, B0, B1, B2, B3, B4, B5, B6, B7, C0, C1, C2, C3, C4, C5, C6, C7
    }
}
