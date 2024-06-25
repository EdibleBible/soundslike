using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoderTrail : MonoBehaviour
{
    [NonSerialized] public List<WebJoint> trailJoints = new();
    [NonSerialized] public List<MoveType> moves = new();
    public List<Sprite> moveSpriteImages = new();
    public enum MoveType { side, up, down };
    public delegate void UpdateMoveSpriteHandler(Sprite moveSpriteImage);
    public event UpdateMoveSpriteHandler UpdateMoveSprite;

    public void StartTrailing(WebJoint initialJoint)
    {
        trailJoints.Clear();
        trailJoints.Add(initialJoint);
    }

    public MoveType ExtendTrail(WebJoint nextJoint)
    {
        int trailLength = trailJoints.Count;
        trailJoints.Add(nextJoint);
        MoveType latestMove = DetectMove(trailJoints[trailLength - 1], trailJoints[trailLength]);
        moves.Add(latestMove);
        Debug.Log(latestMove);
        UpdateMoveSprite.Invoke(moveSpriteImages[(int)latestMove]);
        return latestMove;
    }

    public MoveType DetectMove(WebJoint jointA, WebJoint jointB)
    {
        if (jointA.tag == jointB.tag)
        {
            return MoveType.side;
        } else if (jointA.tag != jointB.tag && jointA.jointCoords < jointB.jointCoords)
        {
            return MoveType.up;
        } else if (jointA.tag != jointB.tag && jointA.jointCoords > jointB.jointCoords)
        {
            return MoveType.down;
        }
        return MoveType.side;
    }
}
