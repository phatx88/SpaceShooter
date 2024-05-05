using System.Collections.Generic;
using UnityEngine;

public class DestroyAndSpawn : MonoBehaviour
{
    [Tooltip("List of prefabs to spawn from.")]
    public List<GameObject> prefabsToSpawn = new List<GameObject>(); // List of prefabs to spawn from
    public Vector3 spawnOffset = Vector3.zero; // Optional offset for spawning the new prefab

    void OnDisable()
    {
        if (GameManager.Instance != null && prefabsToSpawn.Count > 0)
        {
            GameObject randomPrefab = GetRandomPrefab();
            if (randomPrefab != null)
            {
                GameManager.Instance.CreateObject(randomPrefab, transform.position + spawnOffset);
            }
        }
    }

    // Selects a random prefab from the list
    private GameObject GetRandomPrefab()
    {
        int index = Random.Range(0, prefabsToSpawn.Count);
        return prefabsToSpawn[index];
    }
}
