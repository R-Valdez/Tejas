using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followAI : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public float speed = 2f; // Speed of AI movement

    void Update()
    {
        if (target == null)
            return;

        // Calculate direction towards the player
        Vector3 direction = (target.position - transform.position).normalized;

        // Move towards the player
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
