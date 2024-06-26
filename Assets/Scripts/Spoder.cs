using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Enums;
using static SO_Events;

public class Spoder : MonoBehaviour
{
    [NonSerialized] public WebJoint currentJoint; //The joint the player is on
    [NonSerialized] public int direction; //The direction the player is facing
    public SpoderTrail trailScript; //Script which handles the trail the player walks
    public SpoderAttack attackScript; //Script which handles sttacking
    public SO_CurrentLevel levelInfo;

    public AudioSource sourceW;
    public AudioSource sourceA;
    public AudioSource sourceD;

    void Start()
    {
        currentJoint = levelInfo.heartObject.GetComponent<WebJoint>();
        currentJoint.AttachPlayer(this); //Attaches the player to the Center joint assigned in Inspector
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

            sourceW.Play();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentJoint.SwitchRight();
            transform.LookAt(currentJoint.ReturnNextJoint().transform);

            sourceD.Play();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentJoint.SwitchLeft();
            transform.LookAt(currentJoint.ReturnNextJoint().transform);

            sourceA.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space)) //Begins attack & resets the move list & joint history manually
        {
            if (attackScript.CanAttack() && levelInfo.enemiesInLevel.Count != 0)
            {
                Debug.Log(attackScript.GetAttackIndex());
                CallAttackEvent(attackScript.GetAttackIndex());
                trailScript.StartTrailing(currentJoint);
            }
        }
    }
}
