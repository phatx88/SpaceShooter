using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self_Destruct_Swarm : MonoBehaviour
{
    public float timer = 5f;

    void Update()
    {
        // Reduce the self-destruction timer
        timer -= Time.deltaTime;

        // Destroy this object if the timer reaches zero
        if (timer <= 0)
        {
            Destroy(gameObject);
        }

        // Dynamically check if the SwarmSpawner object still exists
        if (GameObject.FindGameObjectWithTag("SwarmSpawner") == null)
        {
            // Destroy this object if the SwarmSpawner object is destroyed
            Destroy(gameObject);
        }
    }
}