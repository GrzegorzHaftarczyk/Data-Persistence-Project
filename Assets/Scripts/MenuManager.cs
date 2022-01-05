using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string userName;

    public int bestScore;

    public string bestUser;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    [System.Serializable]
    class SaveData
    {
        public string lastUser;
        public int bestScore;
        public string bestUser;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.lastUser = userName;
        data.bestScore = bestScore;
        data.bestUser = bestUser;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            userName = data.lastUser;
            bestScore = data.bestScore;
            bestUser = data.bestUser;
        }
    }

}
