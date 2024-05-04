using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public float timeRemaining = 60f;

    // Static variable to hold the instance of the ScoreManager
    //private static ScoreManager instance = null;

    // References to UI elements
    private GameObject scorePanel;
    private CanvasGroup scorePanelGroup;
    //private TextMeshProUGUI scoreText;
    private List<TextMeshProUGUI> scoreTexts = new List<TextMeshProUGUI>();
    private TextMeshProUGUI TimeText;

    //Reference to GameManager
    GameManager gameManager;

    void Awake()
    {
        // Calls the base class's Awake to handle singleton setup
        gameManager = GameManager.Instance;
        InitializeUIComponents();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
                    
            if (timeRemaining <= 0)
            {
                // End of timer: show the score panel and initialize the score text
                if (scorePanel != null)
                {
                    ShowPanel();
                    UpdateScoreDisplay();
                }
            }
            UpdateTimeDisplay();
        }
    }

    public void InitializeUIComponents()
    {
        scorePanel = GameObject.FindGameObjectWithTag("ScorePanel");
        if (scorePanel != null)
        {
            scorePanelGroup = scorePanel.GetComponent<CanvasGroup>();
            HidePanel(); // Initially hide the panel.
        }

        // Initialize the Time Text reference
        TimeText = GameObject.FindGameObjectWithTag("TimeText").GetComponent<TextMeshProUGUI>();

        // Initialize the Time Text reference
        InitializeScoreText();
    }

    private void InitializeScoreText()
    {
        var scoreTextObjects = GameObject.FindGameObjectsWithTag("ScoreText");
        scoreTexts.Clear();  // Clear the list to avoid duplicates

        foreach (GameObject textObj in scoreTextObjects)
        {
            var textComponent = textObj.GetComponent<TextMeshProUGUI>();
            if (textComponent != null)
            {
                scoreTexts.Add(textComponent);
            }
        }
        
        //Debug.Log(scoreTexts);
    }

    private void UpdateScoreDisplay()
    {

        foreach (var text in scoreTexts)
        {
            if (text != null)
                text.text = $"Total Score: {gameManager.GetTotalScore()}\nKills: {gameManager.GetTotalKills()}";
        }
    }

    public void scoreIncreasement(int add)
    {
        score += add;
        gameManager.AddTotalScore(add);
        gameManager.AddKillCount(1);
        // Optionally update the score display in real-time if needed
        UpdateScoreDisplay();
    }

    private void UpdateTimeDisplay()
    {
        // Update the score text if it's not null
        if (TimeText != null)
            TimeText.text = $"Score: {score}\nTime: {(int)timeRemaining}";
    }

    private void HidePanel()
    {
        if(scorePanelGroup != null)
        {
        scorePanelGroup.alpha = 0;  // Make the panel fully transparent.
        scorePanelGroup.blocksRaycasts = false;  // Prevent the panel from blocking raycasts.
        scorePanelGroup.interactable = false;  // Disable interaction.
        Time.timeScale = 1;  // Restart time
        }
    }

    private void ShowPanel()
    {
        if(scorePanelGroup != null)
        {
        scorePanelGroup.alpha = 1;  // Make the panel fully visible.
        scorePanelGroup.blocksRaycasts = true;  // Allow the panel to block raycasts.
        scorePanelGroup.interactable = true;  // Enable interaction.
        Time.timeScale = 0;  // Stop the time
        }
    }

    public void RestartGame()
    {

        // Reset the timer
        timeRemaining = 60f; // Assuming you start with 60 seconds again

        // Reset the score
        score = 0;
        UpdateScoreDisplay();
        UpdateTimeDisplay();

        // Any other resets needed (e.g., player health, position)
        // PlayerHealth.ResetHealth();

        // Optionally hide the score panel if needed
        HidePanel();
    }

    public void ReturnMenu()
    {
        // Optionally hide the score panel if needed
        HidePanel();
    }
}
