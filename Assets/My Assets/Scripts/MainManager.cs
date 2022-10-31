using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    #region "data enclosed"
    public bool IsGameSaved;
    public bool IsGameEnded;
    public bool IsGameJustEnded;
    public bool isHighScoreTriggered;
    public string DifficultyLevel;

    public string PlayerName;
    public float PlayerHealth;
    public float PlayerMaxHealth;

    public Image PlayerChara;

    public float PlayerHiScore;

    public string LastPlayerName;
    public float LastPlayerScore;
    public string BestPlayerName;
    public float BestPlayerScore;
    public string RecentPlayerName;
    public float RecentPlayerScore;

    public float masterVol;
    public float bkgrdMusVol;
    public float fxVol;

    #endregion

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        LoadInfo();
    }

    [System.Serializable]
    class SaveData
    {
        public bool IsGameSaved;
        public bool IsGameEnded;
        public bool IsGameJustEnded;
        public bool isHighScoreTriggered;
        public string DifficultyLevel;

        public string PlayerName;
        public float PlayerHealth;
        public float PlayerMaxHealth;

        public Image PlayerChara;

        public float PlayerHiScore;

        public string LastPlayerName;
        public float LastPlayerScore;
        public string BestPlayerName;
        public float BestPlayerScore;
        public string RecentPlayerName;
        public float RecentPlayerScore;

        public float masterVol;
        public float bkgrdMusVol;
        public float fxVol;
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();

        data.IsGameSaved = IsGameSaved;
        data.IsGameEnded = IsGameEnded;
        data.IsGameJustEnded = IsGameJustEnded;
        data.isHighScoreTriggered = isHighScoreTriggered;
        data.DifficultyLevel = DifficultyLevel;

        data.PlayerName = PlayerName;
        data.PlayerHealth = PlayerHealth;
        data.PlayerMaxHealth = PlayerMaxHealth;

        data.PlayerChara = PlayerChara;

        data.PlayerHiScore = PlayerHiScore;

        data.LastPlayerName = LastPlayerName;
        data.LastPlayerScore = LastPlayerScore;
        data.BestPlayerName = BestPlayerName;
        data.BestPlayerScore = BestPlayerScore;
        data.RecentPlayerName = RecentPlayerName;
        data.RecentPlayerScore = RecentPlayerScore;

        data.masterVol = masterVol;
        data.bkgrdMusVol = bkgrdMusVol;
        data.fxVol = fxVol;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            IsGameSaved = data.IsGameSaved;
            IsGameEnded = data.IsGameEnded;
            IsGameJustEnded = data.IsGameJustEnded;
            isHighScoreTriggered = data.isHighScoreTriggered;
            DifficultyLevel = data.DifficultyLevel;

            PlayerName = data.PlayerName;
            PlayerHealth = data.PlayerHealth;
            PlayerMaxHealth = data.PlayerMaxHealth;

            PlayerChara = data.PlayerChara;

            PlayerHiScore = data.PlayerHiScore;

            LastPlayerName = data.LastPlayerName;
            LastPlayerScore = data.LastPlayerScore;
            BestPlayerName = data.BestPlayerName;
            BestPlayerScore = data.BestPlayerScore;
            RecentPlayerName = data.RecentPlayerName;
            RecentPlayerScore = data.RecentPlayerScore;

            masterVol = data.masterVol;
            bkgrdMusVol = data.bkgrdMusVol;
            fxVol = data.fxVol;
        }
        else
        {
            Debug.Log("there is no save file");
        }
    }
}