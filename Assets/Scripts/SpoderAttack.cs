using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Enums;

public class SpoderAttack : MonoBehaviour
{
    [Tooltip("ScriptableObject which holds all attack patterns")] public SO_Attacks attacks;
    [Tooltip("ScriptableObject which holds the history of moves")] public SO_MoveHistory moveHistory;
    private List<List<MoveType>> attackList = new();
    private int attackIndex = 0;

    private void Start() //Indexes the attacks into a list
    {
        attackList.Clear();
        attackList.Add(attacks.attack0);
        attackList.Add(attacks.attack1);
        attackList.Add(attacks.attack2);
        attackList.Add(attacks.attack3);
        attackList.Add(attacks.attack4);
    }

    public bool CanAttack() //Not tested yet
    {
        attackIndex = 0;
        foreach (var attack in attackList)
        {
            if (moveHistory.moves.Count > 4 &&
                attack[0] == moveHistory.moves[0] &&
                attack[1] == moveHistory.moves[1] &&
                attack[2] == moveHistory.moves[2] &&
                attack[3] == moveHistory.moves[3] &&
                attack[4] == moveHistory.moves[4])
            {
                return true;
            }
            attackIndex++;
        }
        return false;
    }

    public int GetAttackIndex()
    {
        return attackIndex;
    }
}
