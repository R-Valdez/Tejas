using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target; // Reference to the main character's transform
    public float smoothSpeed = 0.125f; // Speed of camera movement
    public Vector3 offset; // Offset of the camera from the character

    public float minX, maxX, minZ, maxZ; // Limits of the play zone

    void LateUpdate()
    {
        if (target == null)
            return;

        // Calculate desired position for the camera
        Vector3 desiredPosition = target.position + offset;

        // Clamp the desired position to stay within play zone limits
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
        desiredPosition.z = Mathf.Clamp(desiredPosition.z, minZ, maxZ);

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
