using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPreFab;

    float spawnDistance = 12f;
    
    float enemyRate = 5;
    float nextEnemy = 1;


    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;

        if (nextEnemy <= 0)
        {
            nextEnemy = enemyRate;

            //Increase enemy rate spawn
            enemyRate *= 0.9f;
            if (enemyRate < 2)
            {
                enemyRate = 5;
            }

            Vector3 offset = Random.onUnitSphere;

            offset.z = 0;

            //set offset area to be outside of camera screen
            offset = offset.normalized * spawnDistance;


            //Stop intantiate Enemy Ship if no more player
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            
            if(go != null)
            {
            Instantiate(enemyPreFab, transform.position + offset, Quaternion.identity);
            }
        }
    }
}
