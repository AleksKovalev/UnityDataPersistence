using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StateStorage : MonoBehaviour
{
    public static StateStorage instance;
    public string currentUserName;
    public BestScore bestScore;

    public void SaveBestScore()
    {
        if (bestScore == null)
        {
            return;
        }
        string json = JsonUtility.ToJson(bestScore);
        File.WriteAllText(Path(), json);
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    void LoadBestScore()
    {
        string path = Path();
        if (File.Exists(path))
        {
            string text = File.ReadAllText(path);
            bestScore = JsonUtility.FromJson<BestScore>(text);
        }
    }

    string Path()
    {
        return Application.persistentDataPath + "/bestScore.json";
    }
}


[System.Serializable]
public class BestScore
{
    public string name;
    public int score;
}
