using System.Collections.Generic;
using UnityEngine;
using static SO_Enums;

public class WebJoint : MonoBehaviour
{
    [Tooltip("The coordinates of this joint on the web")] public JointCoords jointCoords;
    [Tooltip("List of joints in all available 8 directions")] public List<WebJoint> joints = new();
    [HideInInspector] public Spoder player;   //Player component reference; Null if player isnt on this joint
    [HideInInspector] public WebJoint nextJoint;  //Currently faced joint

    public void AttachPlayer(Spoder spoder) //Called at the beginning & when jumping to switch the joint the player is on
    {
        player = spoder; //Saves the reference to the player locally (is null if this joint doesn't have a player right now)
        player.transform.position = transform.position; //Teleports the player to the position of this joint
        nextJoint = ClosestJoint(); //Calls the method to find the next best candidate for the next joint in this direction
        player.transform.LookAt(nextJoint.transform); //Rotates the player to face the next joint
    }

    public WebJoint Jump() //Called by the player to switch the joint
    {
        nextJoint.AttachPlayer(player); // Runs the method to attach the player to the next joint
        player = null; //Removes the reference to the player from this joint (so that when this variable is null you know this joint doesn't have a player right now)
        return nextJoint;   //Returns the reference to the joint the player switched to to the player memory
    }

    public void SwitchLeft() //Turns the player to face the next leftmost joint
    {
        nextJoint = ReturnJointLeft();
    }

    public void SwitchRight() //Turns the player to face the next rightmost joint
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
                return joints[player.direction]; //Returns the joint from the list which is closest at leftmost
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
                return joints[player.direction]; //Returns the joint from the list which is closest at rightmost
            }

        }
    }

    public bool IsJointLeft() //Determines whether there is a joint directly (at 45 degrees) to the left of the player
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

    public bool IsJointRight() //Determines whether there is a joint directly (at 45 degrees) to the right of the player
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

    public WebJoint ReturnNextJoint() //Used by the player script to retrieve the joint which is being faced
    {
        return nextJoint;
    }

    public WebJoint ClosestJoint() //Randomly picks the next joint to face after jumping
    {
        if (joints[player.direction] != null) //First it looks forward. If there is a joint, the direction doesn't change
        {
            return joints[player.direction];
        }

        bool isJointLeft = IsJointLeft();
        bool isJointRight = IsJointRight();

        if (!isJointLeft && !isJointRight) //If there is no joint immediately to either side, it randomly picks either side and searches for a joint there. Used at edges (layer C)
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

        if (tag == "JointC") //Fixes a bug where at the edge (layer C) left & right are switched. It switches them again lmao
        {
            isJointLeft = !isJointLeft;
            isJointRight = !isJointRight;
        }

        //Used at joints A1, A3, A5, A7, B1, B3, B5, B7 when moving sideways to make the player face sideways instead of facing outwards
        if (isJointLeft && !isJointRight)
        {
            return ReturnJointRight();
        }
        if (!isJointLeft && isJointRight)
        {
            return ReturnJointLeft();
        }

        //If anything else fails (though it shouldn't), the direction doesn't change and the script tries to get a joint from there)
        return joints[player.direction];
    }

}
