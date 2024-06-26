using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Events;
using static SO_Enums;

public class SpoderTrail : MonoBehaviour
{
    [Tooltip("The Spoder component of this player")] public Spoder player;
    [Tooltip("Scriptable Object which holds the joint & move history")] public SO_MoveHistory history;
    [Tooltip("Sprites of movement icons in UI (in the order of MoveType enum")] public List<Sprite> moveSpriteImages = new();
    [Tooltip("Material for the LineRenderer")] public Material lineMaterial;
    private LineRenderer lineRenderer;

    private void Start()
    {
        history.trailJoints.Add(player.levelInfo.heartObject); //Brute forces the Center joint into this list so that Moves list can work properly with the first movement
        lineRenderer = GetComponent<LineRenderer>();
        UpdateLineRenderer();
    }

    private void UpdateLineRenderer()
    {
        // Update the position count of the line renderer
        lineRenderer.positionCount = history.trailJoints.Count;

        // Update the positions in the line renderer
        for (int i = 0; i < history.trailJoints.Count; i++)
        {
            lineRenderer.SetPosition(i, history.trailJoints[i].transform.position);
        }
    }

    public void StartTrailing(WebJoint initialJoint) //Restarts the list of moves & joint history
    {
        history.trailJoints.Clear();
        history.trailJoints.Add(initialJoint.gameObject);
        history.moves.Clear();
        // UpdateMoveSprites(history.moves, moveSpriteImages); //Calls the event which updates the UI sprites of the movement history
    }

    void Update()
    {
        UpdateLineRenderer();
    }

    public MoveType ExtendTrail(WebJoint nextJoint) //Handles adding a new entry into the list of moves & joint history
    {
        int trailLength = history.trailJoints.Count;
        history.trailJoints.Add(nextJoint.gameObject);
        MoveType latestMove = DetectMove(history.trailJoints[trailLength - 1].GetComponent<WebJoint>(), history.trailJoints[trailLength].GetComponent<WebJoint>()); //Calls to detect the type of movement between this and the previous movement
        history.moves.Add(latestMove);
        // UpdateMoveSprites(history.moves, moveSpriteImages); //Calls the event which updates the UI sprites of the movement history
        Debug.Log(history.trailJoints[history.trailJoints.Count - 1]);
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
        int trailLength = history.trailJoints.Count;
        WebJoint jointA = history.trailJoints[trailLength - 1].GetComponent<WebJoint>();
        WebJoint jointB = history.trailJoints[trailLength].GetComponent<WebJoint>();
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
