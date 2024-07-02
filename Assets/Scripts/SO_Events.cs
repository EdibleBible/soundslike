using System.Collections.Generic;
using UnityEngine;
using static SO_Enums;

public class SO_Events : ScriptableObject
{
    // Declares the event which updates the movement list UI
    public delegate void UpdateMoveSpriteHandler(List<MoveType> moveList, List<Sprite> moveSprites);
    public static event UpdateMoveSpriteHandler UpdateMoveSprite;
    public static void UpdateMoveSprites(List<MoveType> moves, List<Sprite> sprites)
    {
        UpdateMoveSprite.Invoke(moves, sprites);
    }

    // Declares the event which makes every enemy get attacked
    public delegate void AttackEnemy(int attackIndex);
    public static event AttackEnemy AttackEvent;

    public static void CallAttackEvent(int attackIndex)
    {
        AttackEvent.Invoke(attackIndex);
    }

    // Declares the event which updates the HP display
    public delegate void UpdateHP(int hp);
    public static event UpdateHP UpdateHPEvent;

    public static void CallUpdateHP(int hp) 
    {
        UpdateHPEvent.Invoke(hp);
    }
}
