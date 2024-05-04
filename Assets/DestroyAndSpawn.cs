using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndSpawn : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign this in the Inspector with the prefab you want to spawn
    public Vector3 spawnOffset = Vector3.zero; // Optional offset for spawning the new prefab

    void OnDestroy()
    {
        //if (prefabToSpawn != null)
        //{
        //    // Instantiate the new prefab at the current GameObject's position plus the offset
        //    Instantiate(prefabToSpawn, transform.position + spawnOffset, Quaternion.identity);
        //}

        if (GameManager.Instance != null)
        {
            GameManager.Instance.CreateObject(prefabToSpawn, transform.position);
        }
    }
}
