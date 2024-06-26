using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Events;
using static SO_Enums;

public class SpoderTrail : MonoBehaviour
{
    public Spoder player;
    public List<WebJoint> trailJoints = new();
    public List<MoveType> moves = new();
    public List<Sprite> moveSpriteImages = new();

    private void Start()
    {
        trailJoints.Add(player.firstJoint);
    }

    public void StartTrailing(WebJoint initialJoint)
    {
        trailJoints.Clear();
        trailJoints.Add(initialJoint);
        moves.Clear();
        UpdateMoveSprites(moves, moveSpriteImages);
    }

    public MoveType ExtendTrail(WebJoint nextJoint)
    {
        int trailLength = trailJoints.Count;
        trailJoints.Add(nextJoint);
        MoveType latestMove = DetectMove(trailJoints[trailLength - 1], trailJoints[trailLength]);
        moves.Add(latestMove);
        Debug.Log(latestMove);
        UpdateMoveSprites(moves, moveSpriteImages);
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
