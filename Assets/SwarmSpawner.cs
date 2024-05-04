using UnityEngine;

public class SwarmSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 30f; // Time interval between spawns
    private float nextSpawnTime;

    public int pyramidBaseSize = 5; // Number of ships in the base row of the pyramid

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval; // Set the next spawn time
        // Delay the initial spawn slightly if needed
        Invoke("SpawnPyramid", 0.1f); // Use Invoke to delay the initial spawn to ensure all game elements are loaded
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnPyramid();
            nextSpawnTime += spawnInterval; // Schedule the next spawn
        }
    }

    void SpawnPyramid()
    {
        // Ensure the player is in the scene before spawning enemies
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Debug.Log("No player found, delaying enemy spawn.");
            Invoke("SpawnPyramid", 1.0f); // Try again in 1 second
            return;
        }

        int currentRowSize = 1; // Start with one enemy at the top
        Vector3 spawnPosition;

        for (int row = 0; row < pyramidBaseSize; row++)
        {
            for (int i = 0; i < currentRowSize; i++)
            {
                // Calculate position for each enemy in the row
                float horizontalSpacing = 1.5f; // Horizontal spacing between ships
                spawnPosition = transform.position + new Vector3((i - currentRowSize / 2.0f) * horizontalSpacing, row * 1.5f, -1); // Set z to -1
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
            currentRowSize++; // Increase the size for the next row
        }
    }
}
