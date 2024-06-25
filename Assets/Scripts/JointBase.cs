using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointBase : MonoBehaviour
{
    public Spoder player;
    public JointBase nextJoint;
    public List<JointBase> joints = new();

    public void AttachPlayer(Spoder spoder)
    {
        player = spoder;
        player.transform.position = transform.position;
        player.transform.LookAt(ClosestJoint().transform);
    }

    public JointBase Jump()
    {
        nextJoint.AttachPlayer(player);
        player = null;
        return nextJoint;
    }

    public void SetDirection()
    {
        player.transform.LookAt(nextJoint.transform);
    }

    public void SwitchRight()
    {
        while (true)
        {
            if (player.direction == 7)
            {
                player.direction = 0;
            } else
            {
                ++player.direction;
            }
            if (joints[player.direction] == null)
            {
                continue;
            } else
            {
                nextJoint = joints[player.direction];
                break;
            }

        }
        player.transform.LookAt(nextJoint.transform);
    }

    public void SwitchLeft()
    {
        while (true)
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
                nextJoint = joints[player.direction];
                break;
            }

        }
        player.transform.LookAt(nextJoint.transform);
    }

    public JointBase ClosestJoint()
    {
        if (joints[player.direction] == null)
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
        } else
        {
            return joints[player.direction];
        }
    }
}
