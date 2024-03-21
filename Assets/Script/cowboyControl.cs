using UnityEngine;

public class cowboyControl : MonoBehaviour
{
    public float speed = 5f;
    public AudioClip footstepSound; // Sound to play when the player moves

    private Vector3 previousMoveDirection = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        // Get input from the user using the W, A, S, and D keys
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vertical = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1f;
        }

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Check if the movement direction has changed
        if (moveDirection != previousMoveDirection)
        {
            PlayFootstepSound();
            previousMoveDirection = moveDirection;
        }

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

    // Method to play footstep sound
    void PlayFootstepSound()
    {
        if (footstepSound != null)
        {
            // Create a temporary AudioSource instance
            AudioSource temporaryAudioSource = gameObject.AddComponent<AudioSource>();
            // Lower the volume by half
            temporaryAudioSource.volume = 0.5f;
            // Play the footstep sound
            temporaryAudioSource.PlayOneShot(footstepSound);
            // Destroy the temporary AudioSource instance
            Destroy(temporaryAudioSource, footstepSound.length);
        }
    }
}
