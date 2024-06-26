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
    private List<LineRenderer> lineRenderers = new List<LineRenderer>();

    private void Start()
    {
        history.trailJoints.Add(player.levelInfo.heartObject.GetComponent<WebJoint>()); //Brute forces the Center joint into this list so that Moves list can work properly with the first movement
    }

    public void StartTrailing(WebJoint initialJoint) //Restarts the list of moves & joint history
    {
        history.trailJoints.Clear();
        history.trailJoints.Add(initialJoint);
        history.moves.Clear();
        UpdateMoveSprites(history.moves, moveSpriteImages); //Calls the event which updates the UI sprites of the movement history
    }

    public MoveType ExtendTrail(WebJoint nextJoint) //Handles adding a new entry into the list of moves & joint history
    {
        int trailLength = history.trailJoints.Count;
        history.trailJoints.Add(nextJoint);
        MoveType latestMove = DetectMove(history.trailJoints[trailLength - 1], history.trailJoints[trailLength]); //Calls to detect the type of movement between this and the previous movement
        history.moves.Add(latestMove);
        DrawLine();
        UpdateMoveSprites(history.moves, moveSpriteImages); //Calls the event which updates the UI sprites of the movement history
        return latestMove; // Currently unused but still implemented incase the latest move has to be called
    }

    public void DrawLine()
    {
        GameObject lineObj = new GameObject("Line");
        LineRenderer lineRenderer = lineObj.AddComponent<LineRenderer>();

        // Configure the line renderer
        lineRenderer.material = lineMaterial;
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        // Get the second-to-last and last objects
        GameObject secondToLastObject = history.trailJoints[history.trailJoints.Count - 2].gameObject;
        GameObject lastObject = history.trailJoints[history.trailJoints.Count - 1].gameObject;

        // Set the positions for the line renderer
        lineRenderer.SetPosition(0, secondToLastObject.transform.position);
        lineRenderer.SetPosition(1, lastObject.transform.position);

        // Add the line renderer to the list
        lineRenderers.Add(lineRenderer);
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
        WebJoint jointA = history.trailJoints[trailLength - 1];
        WebJoint jointB = history.trailJoints[trailLength];
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
