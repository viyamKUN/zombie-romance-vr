using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public string UserName = "";
    public List<StageSave> StageClear = new List<StageSave>();

    public SaveData(string username, int stageCount)
    {
        this.UserName = username;
        for (int i = 0; i < stageCount; i++)
        {
            StageClear.Add(new StageSave());
        }
    }
}

[System.Serializable]
public class StageSave
{
    public bool Isclear = false;
    public int HP = 100;
    public string UsingTime = "";
}