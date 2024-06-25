using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebJoint : MonoBehaviour
{
    public WebJointCoord.JointCoords jointCoords; //The coordinates of this joint on the web
    [NonSerialized] public Spoder player;   //Player component reference; Null if player isnt on this joint
    [NonSerialized] public WebJoint nextJoint;  //Currently faced joint
    public List<WebJoint> joints = new();   //List of joints in all available 8 directions

    public void AttachPlayer(Spoder spoder) //Called at the beginning & when jumping to switch the joint the player is on
    {
        player = spoder;
        player.transform.position = transform.position;
        nextJoint = ClosestJoint();
        player.transform.LookAt(nextJoint.transform);
    }

    public WebJoint Jump() //Called by the player to switch the joint
    {
        Debug.Log("Jumped from " + jointCoords + " to " + nextJoint.jointCoords);
        nextJoint.AttachPlayer(player);
        player = null;
        return nextJoint;   //Returns the reference to the joint the player switched to to the player memory
    }

    public void SwitchLeft()
    {
        nextJoint = ReturnJointLeft();
    }

    public void SwitchRight()
    {
        nextJoint = ReturnJointRight();
    }

    public WebJoint ReturnJointLeft() //Searches for the next leftmost joint (more negative values in the list)
    {
        while (true) //Loops through the list of joints and breaks when the list has an entry in the faced direction index
        {
            if (player.direction == 0)
            {
                player.direction = 7;
            }
            else
            {
                --player.direction;
            }
            if (joints[player.direction] == null)
            {
                continue;
            }
            else
            {
                return joints[player.direction];
            }

        }
    }

    public WebJoint ReturnJointRight() //Searches for the next rightmost joint (more positive values in the list)
    {
        while (true)
        {
            if (player.direction == 7)
            {
                player.direction = 0;
            }
            else
            {
                ++player.direction;
            }
            if (joints[player.direction] == null)
            {
                continue;
            }
            else
            {
                return joints[player.direction];
            }

        }
    }

    public bool IsJointLeft()
    {
        int localDirection = player.direction;
        if (localDirection == 0)
        {
            localDirection = 7;
        }
        else
        {
            --localDirection;
        }
        if (joints[localDirection] == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool IsJointRight()
    {
        int localDirection = player.direction;
        if (localDirection == 7)
        {
            localDirection = 0;
        }
        else
        {
            ++localDirection;
        }
        if (joints[localDirection] == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public WebJoint ReturnNextJoint() //Used by the player to retrieve the joint which is being faced
    {
        return nextJoint;
    }

    public WebJoint ClosestJoint() //Randomly picks the next joint to face after jumping
    {
        if (joints[player.direction] != null)
        {
            return joints[player.direction];
        }

        bool isJointLeft = IsJointLeft();
        bool isJointRight = IsJointRight();

        if (!isJointLeft && !isJointRight)
        {
            int randomValue = UnityEngine.Random.Range(0, 2);
            if (randomValue == 0)
            {
                return ReturnJointRight();
            }
            else
            {
                return ReturnJointLeft();
            }
        }
        if (isJointLeft && !isJointRight)
        {
            return ReturnJointRight();
        }
        if (!isJointLeft && isJointRight)
        {
            return ReturnJointLeft();
        }
        return joints[player.direction];
    }

}
