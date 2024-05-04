using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirectionMover : MonoBehaviour
{
    public float rotSpeed = 90f;

    private float randomDirection;

    void Start()
    {
        // Generate a random initial direction at the start
        randomDirection = Random.Range(0f, 360f);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the direction periodically or keep it constant based on your needs
        if (Time.frameCount % 60 == 0)  // Change direction every second if the game runs at 60 FPS
        {
            randomDirection = Random.Range(0f, 360f);
        }

        // Convert the random angle to a quaternion
        Quaternion desiredRot = Quaternion.Euler(0, 0, randomDirection);

        // Smoothly rotate towards the new random direction
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
    }
}
