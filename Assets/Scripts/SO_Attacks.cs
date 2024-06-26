using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Enums;

[CreateAssetMenu(fileName = "SO_Attacks", menuName = "ScriptableObjects/Attacks")]

//List of attacks, right now without names

public class SO_Attacks : ScriptableObject
{
    public List<MoveType> attack0 = new();
    public List<MoveType> attack1 = new();
    public List<MoveType> attack2 = new();
    public List<MoveType> attack3 = new();
    public List<MoveType> attack4 = new();
    public AudioClip attackSound0;
    public AudioClip attackSound1;
    public AudioClip attackSound2;
    public AudioClip attackSound3;
    public AudioClip attackSound4;
}
