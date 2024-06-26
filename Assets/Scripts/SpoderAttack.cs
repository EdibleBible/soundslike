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
        int attackLength;
        int moveHistoryLength = moveHistory.moves.Count;
        int attackIndexShift = 0;
        foreach (var attack in attackList)
        {
            attackLength = attack.Count;
            if (attack.Count > moveHistoryLength)
            {
                attackIndexShift++;
                continue;
            }
            for (int i = 0; i < attackLength; i++)
            {
                if (attack[attackLength - i - 1] != moveHistory.moves[moveHistoryLength - i - 1])
                {
                    attackIndexShift++;
                    continue;
                }
            }
            attackIndex = attackIndexShift;
            return true;
        }
        return false;
    }

    public int GetAttackIndex()
    {
        return attackIndex;
    }
}
