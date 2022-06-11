using System;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    public int _playTimes = 0;
    public int _bestScore = 0;
    public DateTime _lastUpdated;
}
    
public class SaveManager
{
    public string _filePath = "";
    public string _fileName = "saveData.json";
    public SaveData _saveData;

    private static SaveManager instance = null;
    public static SaveManager Instance
    {
        get{
            if (instance == null)
                instance = new SaveManager();

            return instance;
        }
    }

    public void Start()
    {

        //_saveData = new SaveData();
        if (Application.platform == RuntimePlatform.Android) {
        // Android
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer) {
        // iOS
        _filePath = Application.persistentDataPath + "/" + _fileName;
        }       
        else  {
        _filePath = Application.dataPath + "/" + _fileName;
        }
    }
 
    public void Save()
    {
        string json = JsonUtility.ToJson(_saveData);
 
        StreamWriter streamWriter = new StreamWriter(_filePath);
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
    }
     
    public void Load()
    {
        if (File.Exists(_filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(_filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
 
            _saveData = JsonUtility.FromJson<SaveData>(data);
        }
    }
 
}