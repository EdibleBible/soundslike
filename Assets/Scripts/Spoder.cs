using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoder : MonoBehaviour
{
    public JointBase firstJoint;
    public JointBase currentJoint;

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
    }
}
