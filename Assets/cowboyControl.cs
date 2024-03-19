using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cowboyControl : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Get input from the user using the W, A, S, D keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Clamp the input to only allow movement in cardinal directions
        horizontal = Mathf.Clamp(horizontal, -1f, 1f);
        vertical = Mathf.Clamp(vertical, -1f, 1f);

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Check if there is input and move the character
        if (moveDirection.magnitude >= 0.1f)
        {
            // Calculate the rotation angle based on input direction
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;

            // Immediately set the rotation to face the input direction
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            // Move the character in the direction it's facing
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}