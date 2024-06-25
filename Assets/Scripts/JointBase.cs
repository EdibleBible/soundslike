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
        player.transform.LookAt(nextJoint.transform);
    }

    private void Update()
    {
        
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
}
