
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy
    public float knockbackForce = 5f; // Force applied to the enemy when hit by a bullet
    public float knockbackDuration = 0.1f; // Duration of knockback effect

    private bool isKnockedBack = false; // Flag to track if the enemy is currently being knocked back
    private Vector3 knockbackDirection; // Direction of knockback

    void Start()
    {
        // Initialize current health
        currentHealth = maxHealth;
    }

    void Update()
    {
        // If the enemy is knocked back, move it in the knockback direction
        if (isKnockedBack)
        {
            // Modify the knockback direction to ignore the Y axis
            Vector3 knockbackDirectionXZ = new Vector3(knockbackDirection.x, 0f, knockbackDirection.z).normalized;

            // Move the enemy in the modified knockback direction
            transform.Translate(knockbackDirectionXZ * knockbackForce * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the enemy is hit by a bullet
        if (other.CompareTag("Bullet"))
        {
            // Decrease enemy health
            currentHealth--;

            // Calculate knockback direction
            knockbackDirection = (transform.position - other.transform.position).normalized;

            // Start knockback effect
            StartKnockback();

            // Check if the enemy has been defeated
            if (currentHealth <= 0)
            {
                // Enemy is defeated, you can add further logic here such as playing death animations, etc.
                Destroy(gameObject);
            }
        }
    }

    void StartKnockback()
    {
        // Set the flag to indicate that the enemy is knocked back
        isKnockedBack = true;

        // Start a coroutine to end the knockback effect after a certain duration
        StartCoroutine(EndKnockback());
    }

    IEnumerator EndKnockback()
    {
        // Wait for the knockback duration
        yield return new WaitForSeconds(knockbackDuration);

        // Reset the flag to indicate that the knockback effect has ended
        isKnockedBack = false;
    }
}

