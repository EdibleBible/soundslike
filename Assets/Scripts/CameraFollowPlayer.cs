using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [Tooltip("If enabled, this feature will work")] public bool isEnabled;
    [Tooltip("Player parent object Transform")] public Transform player;
    [Tooltip("The distance of the camera from behind the player")] public Vector3 offset;
    [Tooltip("Lerp transition speed (1 is instant)")] public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (isEnabled)
        {
            Vector3 desiredPosition = player.position + player.rotation * offset;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;

            transform.LookAt(player.position + Vector3.up * 1.5f);
        }
    }
}
