using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string playerName;
    public int highScore;

    [System.Serializable]
    class SaveData{
        public string playerName;
        public int highScore;
    }

    public void StoreData(){
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);

    }

    public void LoadData(){
        string path  = Application.persistentDataPath+ "/saveData.json";
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            highScore = data.highScore;
        }
    }


    private void Awake() {
        if(Instance != null){
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        //load settings here
        LoadData();

    }
}
