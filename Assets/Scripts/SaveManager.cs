using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public float Highscore;
    public string playerName;

    [System.Serializable]
    class SaveData
    {
        public float Highscore;
        public string playerName;
    }
    
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighscore();
    }
    
    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Highscore = data.Highscore;
            playerName = data.playerName;
        }
    }
    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.Highscore = Highscore;
        data.playerName = playerName;
 

        string json = JsonUtility.ToJson(data);
        Debug.Log("Saving data: " + json.ToString());
        
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    

}
