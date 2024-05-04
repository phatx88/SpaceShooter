using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private ScoreManager scoreManager;
    void Awake()
    {
   
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        
    }
    public void PlayGame()
    {
        Debug.Log("Loading Scene 1");
        // Load the first level; here '1' assumes your first level is at index 1 in the Build Settings
        SceneManager.LoadSceneAsync(1);
    }

    public void NextLevel()
    {
        Debug.Log("Attempting to load the next level.");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        Debug.Log($"Current scene index: {currentSceneIndex}, Loading next scene index: {nextSceneIndex}");

        // Restart the current score and time
        scoreManager.RestartGame();
        SceneManager.LoadSceneAsync(nextSceneIndex);
    }

    public void Restart()
    {
        // Restart the current score and time
        scoreManager.RestartGame();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex);       
    }

    public void ReturnMenu()
    {
        scoreManager.ReturnMenu();
        // Load the main menu; assumes your main menu is at index 0 in the Build Settings
        SceneManager.LoadSceneAsync(0);

    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();

        // If running inside the Unity editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
