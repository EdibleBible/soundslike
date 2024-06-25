using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WebJointCoord;

public class Spoder : MonoBehaviour
{
    public WebJoint firstJoint; //The center joint the player is attached to at the beginning of the game
    [NonSerialized] public WebJoint currentJoint; //The joint the player is on
    [NonSerialized] public int direction; //The direction the player is facing
    public SpoderTrail trailScript; //Script which handles the trail the player walks

    void Start()
    {
        firstJoint.AttachPlayer(this);
        currentJoint = firstJoint;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentJoint.jointCoords == JointCoords.Center)
            {
                trailScript.StartTrailing(currentJoint);
            }
            currentJoint = currentJoint.Jump();
            trailScript.ExtendTrail(currentJoint);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentJoint.SwitchRight();
            transform.LookAt(currentJoint.ReturnNextJoint().transform);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentJoint.SwitchLeft();
            transform.LookAt(currentJoint.ReturnNextJoint().transform);
        }
    }
}
