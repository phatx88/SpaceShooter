using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonPersistent<GameManager>
{
    private float totalPlayTime = 0;
    private int totalScore = 0;
    private int killCount = 0;
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        // Optionally load saved playtime if needed
        LoadPlayTime();
    }

    // Update is called once per frame
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
    //Create Gameobject through Instance
    public void CreateObject(GameObject prefab, Vector3 position)
    {
        Instantiate(prefab, position, Quaternion.identity);
    }

}
