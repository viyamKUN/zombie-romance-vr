using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;
using ConversationModles;

public class DataManager : MonoBehaviour
{
    [SerializeField] private int _stageNum = 5;
    [SerializeField] private CSVReader _csvReader = null;
    private SaveData _mySaveData;

    private List<Conversation> _conversationList = null;

    public void SetData(out bool isGameDataExist)
    {
        _conversationList = _csvReader.readConversation();
        isGameDataExist = LoadGame();
    }

    public void Init(string name = "Guest")
    {
        _mySaveData = new SaveData(name, _stageNum);
        SaveGame();
    }
    public void SaveGame()
    {
        var filename = SaveFileName.PlayerDataFileName;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(filename);
        binaryFormatter.Serialize(file, _mySaveData);
        file.Close();
    }
    public bool LoadGame()
    {
        var filename = SaveFileName.PlayerDataFileName;
        if (!File.Exists(filename)) return false;
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Open(filename, FileMode.Open);
        if (file != null && file.Length > 0)
        {
            _mySaveData = (SaveData)binaryFormatter.Deserialize(file);
            file.Close();
            return true;
        }
        return false;
    }
    public void DeleteGame()
    {
        var filename = SaveFileName.PlayerDataFileName;
        File.Delete(filename);
    }

    public string UserName
    {
        get => _mySaveData.UserName; set => _mySaveData.UserName = value;
    }
    public Conversation GetRandomConversation()
    {
        return _conversationList[Random.Range(0, _conversationList.Count)];
    }
}
