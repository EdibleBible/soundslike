using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Enums;
using static SO_Events;

public class Spoder : MonoBehaviour
{
    public WebJoint firstJoint; //The center joint the player is attached to at the beginning of the game
    [NonSerialized] public WebJoint currentJoint; //The joint the player is on
    [NonSerialized] public int direction; //The direction the player is facing
    public SpoderTrail trailScript; //Script which handles the trail the player walks
    public SpoderAttack attackScript; //Script which handles sttacking

    void Start()
    {
        firstJoint.AttachPlayer(this); //Attaches the player to the Center joint assigned in Inspector
        currentJoint = firstJoint; //Sets the current joint reference in palyer memory to be the Center joint
        trailScript.StartTrailing(currentJoint); //Idk if it actually works lmao
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //Key for jumping forwards
        {
            currentJoint = currentJoint.Jump(); //Attaches the player to a magically determined joint (simply - next joint)
            trailScript.ExtendTrail(currentJoint); //Handles adding new entries to the move list & joint history
            if (currentJoint.jointCoords == JointCoords.Center) //Resets the move list & joint history when the player gets to the Center
            {
                trailScript.StartTrailing(currentJoint);
            }
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
        if (Input.GetKeyDown(KeyCode.Space)) //Begins attack & resets the move list & joint history manually
        {
            if (attackScript.CanAttack())
            {
                Debug.Log(attackScript.GetAttackIndex());
                CallAttackEvent(attackScript.GetAttackIndex());
                trailScript.StartTrailing(currentJoint);
            }
        }
    }
}
