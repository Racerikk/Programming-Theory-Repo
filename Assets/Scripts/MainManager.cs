using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public float spawnInterval;
    public float scoreAddTimer; 

    public int highScore;
    public string playerName;
    public string highscorerName;
    public static MainManager Instance;
    void Start()
    {
        LoadData();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void NewHighScoreReached()
    {
        highScore = ScoreManager.instance.score;
        highscorerName = playerName;
        SaveDataMethod();
    }

    [Serializable]
    public class SaveData
    {
        public int highScore;
        public string highscorerName;
    }

    public void SaveDataMethod()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highscorerName = highscorerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = new SaveData();
            data = JsonUtility.FromJson<SaveData>(json);
            highscorerName = data.highscorerName;
            highScore = data.highScore;
        }
    }
}
