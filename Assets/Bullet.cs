using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private TrailRenderer trailRenderer;

    void Start()
    {
        // Get the Trail Renderer component
        trailRenderer = GetComponent<TrailRenderer>();

        // Enable the Trail Renderer
        trailRenderer.enabled = true;

        // Start moving the bullet forward
        MoveBulletForward();
    }

    void MoveBulletForward()
    {
        // Move the bullet forward in its local forward direction
        // You would implement your bullet movement logic here
    }

    void DestroyBullet()
    {
        // Disable the Trail Renderer before destroying the bullet
        trailRenderer.enabled = false;

        // Destroy the bullet
        Destroy(gameObject);
    }
}

