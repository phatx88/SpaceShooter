using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRandom : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  // Array of different enemy prefabs

    float spawnDistance = 12f;
    float enemyRate = 5;
    float nextEnemy = 1;

    void Update()
    {
        nextEnemy -= Time.deltaTime;

        if (nextEnemy <= 0)
        {
            nextEnemy = enemyRate;

            // Increase enemy spawn rate
            enemyRate *= 0.9f;
            if (enemyRate < 2)
            {
                enemyRate = 5;  // Reset to initial spawn rate if too fast
            }

            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;  // Ensure enemy spawns in a 2D plane
            offset = offset.normalized * spawnDistance;  // Set offset area to be outside of camera screen

            // Check if there is still a player in the game
            GameObject go = GameObject.FindGameObjectWithTag("Player");

            if (go != null && enemyPrefabs.Length > 0)
            {
                // Randomly select an enemy prefab from the array
                GameObject enemyPrefabToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                Instantiate(enemyPrefabToSpawn, transform.position + offset, Quaternion.identity);
            }
        }
    }
}