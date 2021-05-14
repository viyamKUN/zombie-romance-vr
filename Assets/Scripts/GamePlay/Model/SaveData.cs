using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public string UserName = "";
    public List<int> StageClear = new List<int>();

    public SaveData(string username, int stageCount)
    {
        this.UserName = username;
        for (int i = 0; i < stageCount; i++)
            StageClear.Add(-1);
    }
}
