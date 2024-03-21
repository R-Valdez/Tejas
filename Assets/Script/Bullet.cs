using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip barrelDestroySound; // Sound to play when destroying a barrel
    private TrailRenderer trailRenderer;
    private AudioSource audioSource;

    void Start()
    {
        // Get the Trail Renderer component
        trailRenderer = GetComponent<TrailRenderer>();

        // Enable the Trail Renderer
        trailRenderer.enabled = true;

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Start moving the bullet forward
        MoveBulletForward();
    }

    void MoveBulletForward()
    {
        // Move the bullet forward in its local forward direction
        // You would implement your bullet movement logic here
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the bullet hits an object tagged as "Barrel"
        if (other.CompareTag("Barrel"))
        {
            // Play the barrel destroy sound if available
            if (barrelDestroySound != null && audioSource != null)
            {
                audioSource.PlayOneShot(barrelDestroySound);
            }

            // Destroy the bullet first
           

            // Then destroy the barrel
            Destroy(other.gameObject);
            
            
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        // Disable the Trail Renderer before destroying the bullet
        trailRenderer.enabled = false;

        // Destroy the bullet
        Destroy(gameObject,0.5f);
    }
}
