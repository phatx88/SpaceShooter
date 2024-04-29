using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject playerInstance;

    public int numLives = 4;

    float respawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInstance == null && numLives > 0)
        {
            respawnTimer -= Time.deltaTime;

            if(respawnTimer <= 0)
            {
            SpawnPlayer();

            }
        }

    }

    void SpawnPlayer()
    {
        numLives--;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        playerInstance.name = "PlayerShip";
    }

    private void OnGUI()
    {
        if (numLives > 0 || playerInstance != null)
        {
        GUI.Label(new Rect(0, 0, 100, 50), $"Lives Left: {numLives}");

        }
        else
        {
            //Add GameOver Panel Message 
            GUI.Label(new Rect(Screen.width/2 - 50, Screen.height/2 - 25, 100, 50), $"Game Over!");

        }
    }
}
