using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoder : MonoBehaviour
{
    public JointBase firstJoint;
    public JointBase currentJoint;
    public int direction;

    void Start()
    {
        firstJoint.AttachPlayer(this);
        currentJoint = firstJoint;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentJoint =  currentJoint.Jump();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentJoint.SwitchRight();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentJoint.SwitchLeft();
        }
    }
}
