using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SO_Enums;
using static SO_Events;

public class Spoder : MonoBehaviour
{
    [NonSerialized] public WebJoint currentJoint; //The joint the player is on
    [NonSerialized] public int direction; //The direction the player is facing
    public SpoderTrail trailScript; //Script which handles the trail the player walks
    public SpoderAttack attackScript; //Script which handles sttacking
    public SO_CurrentLevel levelInfo;
    public AudioSource source;
    public AudioClip soundTurn;
    public AudioClip soundUp;
    public AudioClip soundDown;
    public AudioClip soundRight;
    public AudioClip soundLeft;
    public AudioClip soundAttack0;
    public AudioClip soundAttack1;
    public AudioClip soundAttack2;
    public AudioClip soundAttack3;
    public AudioClip soundAttack4;

    private void Awake()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
    }

    void Start()
    {
        levelInfo.levelTime = 0;
        currentJoint = levelInfo.heartObject.GetComponent<WebJoint>();
        currentJoint.AttachPlayer(this); //Attaches the player to the Center joint assigned in Inspector
        trailScript.StartTrailing(currentJoint); //Idk if it actually works lmao
    }

    void Update()
    {
        levelInfo.levelTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.W)) //Key for jumping forwards
        {
            currentJoint = currentJoint.Jump(); //Attaches the player to a magically determined joint (simply - next joint)
            MoveType thisMove = trailScript.ExtendTrail(currentJoint); //Handles adding new entries to the move list & joint history
            if (currentJoint.jointCoords == JointCoords.Center) //Resets the move list & joint history when the player gets to the Center
            {
                trailScript.StartTrailing(currentJoint);
            }
            switch (thisMove)
            {
                case MoveType.up:
                    source.clip = soundUp;
                    break;
                case MoveType.down:
                    source.clip = soundDown;
                    break;
                case MoveType.right:
                    source.clip = soundRight;
                    break;
                case MoveType.left:
                    source.clip = soundLeft;
                    break;
            }
            source.Play();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentJoint.SwitchRight();
            transform.LookAt(currentJoint.ReturnNextJoint().transform);
            source.clip = soundTurn;
            source.Play();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentJoint.SwitchLeft();
            transform.LookAt(currentJoint.ReturnNextJoint().transform);
            source.clip = soundTurn;
            source.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space)) //Begins attack & resets the move list & joint history manually
        {
            if (attackScript.CanAttack())
            {
                int attackIndex = attackScript.GetAttackIndex();
                switch (attackIndex)
                {
                    case 0:
                        source.clip = soundAttack0;
                        break;
                    case 1:
                        source.clip = soundAttack1;
                        break;
                    case 2:
                        source.clip = soundAttack2;
                        break;
                    case 3:
                        source.clip = soundAttack3;
                        break;
                    case 4:
                        source.clip = soundAttack4;
                        break;
                }
                source.Play();
                CallAttackEvent(attackIndex);
                trailScript.StartTrailing(currentJoint);
            }
        }
    }
}
