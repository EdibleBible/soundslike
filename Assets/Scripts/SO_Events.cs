using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Enums;

[CreateAssetMenu(fileName = "SO_Events", menuName = "ScriptableObjects/Events")]

public class SO_Events : ScriptableObject
{
    // Declares the event which updates the movement list UI
    public delegate void UpdateMoveSpriteHandler(List<MoveType> moveList, List<Sprite> moveSprites);
    public static event UpdateMoveSpriteHandler UpdateMoveSprite;
    public static void UpdateMoveSprites(List<MoveType> moves, List<Sprite> sprites) //Called by the player trail script (can't just Invoke from there)
    {
        UpdateMoveSprite.Invoke(moves, sprites);
    }
}
