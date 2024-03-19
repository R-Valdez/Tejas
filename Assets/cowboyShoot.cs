

using System.Collections; // Add this line
using UnityEngine;

public class cowboyShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public float bulletSpeed = 10f; // Speed of the bullet
    public Transform shootPoint; // Specify the shoot point in the Inspector

    void Update()
    {
        // Check for input to shoot bullets
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Ensure a shoot point is specified
            if (shootPoint != null)
            {
                // Shoot bullet from the shoot point
                ShootBullet(shootPoint.position);
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
}



