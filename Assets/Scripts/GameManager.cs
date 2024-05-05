using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonPersistent<GameManager>
{
    private float totalPlayTime = 0;
    private int totalScore = 0;
    private int killCount = 0;
    private List<GameObject> managedObjects = new List<GameObject>();

    void Start()
    {
        // Optionally load saved playtime if needed
        LoadPlayTime();
    }

    void Update()
    {
        // Increment the total play time by the time passed since the last frame
        totalPlayTime += Time.deltaTime;
    }

    private void OnApplicationQuit()
    {
        // Optionally save the playtime when the application is quitting
        SavePlayTime();
    }

    private void OnApplicationPause(bool pause)
    {
        // Optionally save the playtime when the application is paused
        if (pause)
        {
            SavePlayTime();
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void SavePlayTime()
    {
        // Save totalPlayTime to PlayerPrefs or a file
        PlayerPrefs.SetFloat("TotalPlayTime", totalPlayTime);
        PlayerPrefs.Save();
    }

    private void LoadPlayTime()
    {
        // Load totalPlayTime from PlayerPrefs if it exists
        if (PlayerPrefs.HasKey("TotalPlayTime"))
        {
            totalPlayTime = PlayerPrefs.GetFloat("TotalPlayTime");
        }
    }

    public void AddTotalScore(int add)
    {
        totalScore += add;
    }

    public void AddKillCount(int add)
    {
        killCount += add;
    }

    public int GetTotalScore()
    {
        return totalScore;
    }

    public int GetTotalKills()
    {
        return killCount;
    }

    public void CreateObject(GameObject prefab, Vector3 position)
    {
        CreateObject(prefab, position, Quaternion.identity);
    }

    public void CreateObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (prefab != null)
        {
            GameObject newObj = Instantiate(prefab, position, rotation);
            managedObjects.Add(newObj);
        }
    }

    private void OnSceneUnloaded(Scene current)
    {
        CleanUpManagedObjects();
    }

    public void CleanUpManagedObjects()
    {
        foreach (GameObject obj in managedObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }

        managedObjects.Clear();
    }
}
