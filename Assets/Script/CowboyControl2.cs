using UnityEngine;

public class CowboyControl2 : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Get input from the user using the arrow keys
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vertical = -1f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1f;
        }

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
