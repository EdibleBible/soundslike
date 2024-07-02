using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Tooltip("Forward movement speed")] public float movementSpeed = 1f;
    private Rigidbody rb;

    void Awake()
    {
        // Get the Rigidbody component attached to the GameObject
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Calculate the forward movement vector
        Vector3 forwardMovement = transform.forward * movementSpeed * Time.fixedDeltaTime;

        // Move the Rigidbody forward
        rb.MovePosition(rb.position + forwardMovement);
    }
}
