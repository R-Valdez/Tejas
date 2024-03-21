using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelManager : MonoBehaviour
{
    public GameObject barrelPrefab; // Reference to the barrel prefab
    public Transform spawnPoint; // Specify the spawn point for barrels in the Inspector
    public AudioClip barrelSpawnSound; // Sound to play when spawning a barrel
    public AudioClip barrelDestroySound; // Sound to play when destroying a barrel
    public AudioClip noBarrel; // Sound to play when the maximum limit of barrels is reached
    public int maxBarrels = 10; // Maximum number of barrels the player can spawn

    private int currentBarrels = 0; // Current number of spawned barrels
    private int barrelsDestroyed = 0; // Number of barrels destroyed
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check for input to spawn barrels
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (currentBarrels == maxBarrels)
            {
                audioSource.PlayOneShot(noBarrel);
            }
            else
            {
                SpawnBarrel();
            }
        }
    }

    void SpawnBarrel()
    {
        // Ensure a spawn point is specified
        if (spawnPoint != null)
        {
            // Instantiate a barrel prefab at the spawn point
            GameObject newBarrel = Instantiate(barrelPrefab, spawnPoint.position, Quaternion.identity);
            currentBarrels++;

            // Play the barrel spawn sound
            if (barrelSpawnSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(barrelSpawnSound);
            }
        }
        else
        {
            Debug.LogError("No spawn point specified for barrels!");
        }
    }

    public void DestroyBarrel(GameObject barrel)
    {
        // Play the barrel destroy sound
        if (barrelDestroySound != null && audioSource != null)
        {
            audioSource.PlayOneShot(barrelDestroySound);
        }

        // Increment the count of destroyed barrels
        barrelsDestroyed++;

        // Decrement the current number of barrels
        currentBarrels--;

        // Check if the number of destroyed barrels reaches the maximum limit
        if (barrelsDestroyed == maxBarrels)
        {
            // Display a message indicating that the player has won
            Debug.Log("Player has destroyed all barrels!");
        }

        // Delay the destruction of the barrel to ensure the destroy sound is heard
        StartCoroutine(DestroyBarrelWithDelay(barrel));
    }

    IEnumerator DestroyBarrelWithDelay(GameObject barrel)
    {
        // Wait for a short delay
        yield return new WaitForSeconds(0.5f);

        // Destroy the barrel
        Destroy(barrel);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the barrel collides with Bullet2
        if (other.CompareTag("Bullet"))
        {
            print("collided");
            // Increment the barrels destroyed counter
            barrelsDestroyed++;
        }
    }
}
