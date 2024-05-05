using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPreFab;

    float spawnDistance = 12f;
    
    public float NextRate = 1f;
    public float maxNextRate = 4f;
    //public int totalMaxEnemy = 5;
    //private int totalEnemy = 0;

    private void Start()
    {
        StartCoroutine(Spamner());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator Spamner()
    {
        do
        {

            InstatiateEnemy();
            //totalEnemy++;

            //Increase enemy rate spawn by 10 percent
            NextRate *= 0.9f;
            if (NextRate < 1)
            {
                NextRate = maxNextRate; //reset Enemy spawn to 4sec
            }
            yield return new WaitForSeconds(maxNextRate);
          yield return null; //khong bi dung game 
        } while (true); //5 prefabs max is 20 ships

    }

    private void InstatiateEnemy()
    {
        Vector3 offset = Random.onUnitSphere;

        offset.z = 0;

        //set offset area to be outside of camera screen
        offset = offset.normalized * spawnDistance;


        //Stop intantiate Enemy Ship if no more player
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        if (go != null)
        {
            Instantiate(enemyPreFab, transform.position + offset, Quaternion.identity);
        }
    }
}
