using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoder : MonoBehaviour
{
    public WebJoint firstJoint; //The center joint the player is attached to at the beginning of the game
    [NonSerialized] public WebJoint currentJoint; //The joint the player is on
    [NonSerialized] public int direction; //The direction the player is facing
    [NonSerialized] public bool isMoving; //Whether the player is moving (for Lerp purposes)

    void Start()
    {
        firstJoint.AttachPlayer(this);
        currentJoint = firstJoint;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentJoint = currentJoint.Jump();
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
