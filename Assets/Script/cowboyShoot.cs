using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cowboyShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public float bulletSpeed = 10f; // Speed of the bullet
    public Transform shootPoint; // Specify the shoot point in the Inspector
    public AudioClip shootSound; // Sound to play when shooting
    public AudioClip pauseSound; // Sound to play during pause

    private AudioSource audioSource; // Reference to the AudioSource component
    private int bulletsFired = 0; // Counter for bullets fired
    private bool isPaused = false; // Flag to indicate if shooting is paused

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if shooting is paused
        if (isPaused)
            return;

        // Check for input to shoot bullets
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Ensure a shoot point is specified
            if (shootPoint != null)
            {
                // Shoot bullet from the shoot point
                ShootBullet(shootPoint.position);

                // Increment bullets fired counter
                bulletsFired++;

                // Play the shoot sound
                if (shootSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(shootSound);
                }

                // Check if the number of bullets fired is a multiple of 6
                if (bulletsFired % 6 == 0)
                {
                    // Pause shooting for a moment
                    StartCoroutine(ShootPause());
                }
            }
            else
            {
                Debug.LogError("No shoot point specified!");
            }
        }
    }

    void ShootBullet(Vector3 spawnPosition)
    {
        // Instantiate a bullet prefab at the spawn position with the same rotation as the player
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, transform.rotation);

        // Start moving the bullet forward continuously
        StartCoroutine(MoveBullet(bullet));
    }

    IEnumerator MoveBullet(GameObject bullet)
    {
        while (true)
        {
            // Move the bullet forward in its local forward direction
            bullet.transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

            // Wait for the next frame
            yield return null;
        }
    }

    IEnumerator ShootPause()
    {
        // Disable shooting during the pause
        isPaused = true;

        // Play pause sound
        if (pauseSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pauseSound);
        }

        // Wait for the pause duration
        yield return new WaitForSeconds(.8f); // Adjust the duration as needed

        // Enable shooting after the pause
        isPaused = false;
    }
}
