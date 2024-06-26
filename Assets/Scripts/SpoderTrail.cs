using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Events;
using static SO_Enums;

public class SpoderTrail : MonoBehaviour
{
    [Tooltip("The Spoder component of this player")] public Spoder player;
    [NonSerialized] public List<WebJoint> trailJoints = new();
    [NonSerialized] public List<MoveType> moves = new();
    [Tooltip("Sprites of movement icons in UI (in the order of MoveType enum")] public List<Sprite> moveSpriteImages = new();

    private void Start()
    {
        trailJoints.Add(player.firstJoint); //Brute forces the Center joint into this list so that Moves list can work properly with the first movement
    }

    public void StartTrailing(WebJoint initialJoint) //Restarts the list of moves & joint history
    {
        trailJoints.Clear();
        trailJoints.Add(initialJoint);
        moves.Clear();
        UpdateMoveSprites(moves, moveSpriteImages); //Calls the event which updates the UI sprites of the movement history
    }

    public MoveType ExtendTrail(WebJoint nextJoint) //Handles adding a new entry into the list of moves & joint history
    {
        int trailLength = trailJoints.Count;
        trailJoints.Add(nextJoint);
        MoveType latestMove = DetectMove(trailJoints[trailLength - 1], trailJoints[trailLength]); //Calls to detect the type of movement between this and the previous movement
        moves.Add(latestMove);
        UpdateMoveSprites(moves, moveSpriteImages); //Calls the event which updates the UI sprites of the movement history
        return latestMove; // Currently unused but still implemented incase the latest move has to be called
    }

    //DANGER ZONE WORKS MYSTERIOUSLY

    public MoveType DetectMove(WebJoint jointA, WebJoint jointB) //Used to detect the movement type, mostly for UI arrows
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

    public MoveType DetectMove() //Used to detect the movement type, mostly for determining player rotation 
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
