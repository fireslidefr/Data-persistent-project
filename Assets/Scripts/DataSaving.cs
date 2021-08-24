using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataSaving : MonoBehaviour
{

    public string playerName;
    public int Score;
    public string BestName = "none";
    public int BestScore = 0;

    public static DataSaving Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            DontDestroyOnLoad(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public string BestName;
        public int BestScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.BestName = BestName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.BestScore;
            BestName = data.BestName;
        }
    }

    public void NewBestScore()
    {
        BestScore = Score;
        BestName = playerName;
    }
}
