using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoderTrail : MonoBehaviour
{
    public List<WebJoint> trailJoints = new();
    public List<MoveType> moves = new();
    public enum MoveType { side, up, down };

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
