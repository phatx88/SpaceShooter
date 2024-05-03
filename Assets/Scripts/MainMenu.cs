using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : SingletonPersistent<MainMenu>
{
    private ScoreManager scoreManager;
    private void Awake()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }
    public void PlayGame()
    {
        // Load the first level; here '1' assumes your first level is at index 1 in the Build Settings
        SceneManager.LoadSceneAsync(1);
    }

    public void NextLevel()
    {
        // Get the current scene index and load the next one
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex + 1);
    }

    public void Restart()
    {
        // Restart the current level
        scoreManager.RestartGame();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex);
    }

    public void ReturnMenu()
    {
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
