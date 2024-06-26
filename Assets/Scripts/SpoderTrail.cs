using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoderTrail : MonoBehaviour
{
    private List<WebJoint> trailJoints = new();
    private List<MoveType> moves = new();
    public List<Sprite> moveSpriteImages = new();
    public enum MoveType { side, up, down, right, left };
    public delegate void UpdateMoveSpriteHandler(List<MoveType> moveList);
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
        UpdateMoveSprite.Invoke(moves);
        return latestMove;
    }

    public MoveType DetectMove(WebJoint jointA, WebJoint jointB)
    {
        if (jointA.tag == jointB.tag)
        {
            if ((jointA.jointCoords > jointB.jointCoords && (int)jointA.jointCoords - (int)jointB.jointCoords != 7) || (int)jointB.jointCoords - (int)jointA.jointCoords == 7)
            {
                return MoveType.left;
            }
            return MoveType.right;
        } else if (jointA.tag != jointB.tag && jointA.jointCoords < jointB.jointCoords)
        {
            return MoveType.up;
        } else if (jointA.tag != jointB.tag && jointA.jointCoords > jointB.jointCoords)
        {
            return MoveType.down;
        }
        return MoveType.side;
    }

    public MoveType DetectMove()
    {
        int trailLength = trailJoints.Count;
        WebJoint jointA = trailJoints[trailLength - 1];
        WebJoint jointB = trailJoints[trailLength];
        if (jointA.tag == jointB.tag)
        {
            if ((jointA.jointCoords > jointB.jointCoords && (int)jointA.jointCoords - (int)jointB.jointCoords != 7) || (int)jointB.jointCoords - (int)jointA.jointCoords == 7)
            {
                return MoveType.left;
            }
            return MoveType.right;
        }
        else if (jointA.tag != jointB.tag && jointA.jointCoords < jointB.jointCoords)
        {
            return MoveType.up;
        }
        else if (jointA.tag != jointB.tag && jointA.jointCoords > jointB.jointCoords)
        {
            return MoveType.down;
        }
        return MoveType.side;
    }
}
