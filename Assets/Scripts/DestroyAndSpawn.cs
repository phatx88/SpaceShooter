using UnityEngine;

public class DestroyAndSpawn : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign this in the Inspector with the prefab you want to spawn
    public Vector3 spawnOffset = Vector3.zero; // Optional offset for spawning the new prefab

    void OnDisable()
    {
        if (GameManager.Instance != null && prefabToSpawn != null)
        {
            GameManager.Instance.CreateObject(prefabToSpawn, transform.position + spawnOffset);
        }
    }
}
