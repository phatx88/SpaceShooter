using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject playerInstance;
    //reference to GUI elements
    private TextMeshProUGUI GUI;
    private GameObject gameOverPanel;
    private CanvasGroup gameOverPanelGroup;

    public int numLives = 4;

    float respawnTimer;
    // Start is called before the first frame update

    private void Awake()
    {
        GUI = GameObject.FindGameObjectWithTag("GUI").GetComponent<TextMeshProUGUI>();

        gameOverPanel = GameObject.FindGameObjectWithTag("GameOverPanel");
        if (gameOverPanel != null)
        {
            gameOverPanelGroup = gameOverPanel.GetComponent<CanvasGroup>();
            HidePanel(); // Initially hide the panel.
        }
    }

    void Start()
    {
        SpawnPlayer();
       
    }

    // Update is called once per frame
    void Update()
    {
        GUIupdate();
        if(playerInstance == null && numLives > 0)
        {
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0)
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

    private void GUIupdate()
    {
        if (numLives > 0 || playerInstance != null)
        {
            GUI.text = $"Lives: {numLives}";

        }
        else
        {
            //Add GameOver Panel Message 
            if (gameOverPanel != null)
            {
                ShowPanel();
                
            }

        }
    }

    private void HidePanel()
    {
        if (gameOverPanelGroup != null) 
        { 
        gameOverPanelGroup.alpha = 0;  // Make the panel fully transparent.
        gameOverPanelGroup.blocksRaycasts = false;  // Prevent the panel from blocking raycasts.
        gameOverPanelGroup.interactable = false;  // Disable interaction.
        Time.timeScale = 1; //Unpause the time
        }
    }

    private void ShowPanel()
    {
        if (gameOverPanelGroup != null) 
        { 
        gameOverPanelGroup.alpha = 1;  // Make the panel fully visible.
        gameOverPanelGroup.blocksRaycasts = true;  // Allow the panel to block raycasts.
        gameOverPanelGroup.interactable = true;  // Enable interaction.
        Time.timeScale = 0;  // Stop the time
        }
    }
}
