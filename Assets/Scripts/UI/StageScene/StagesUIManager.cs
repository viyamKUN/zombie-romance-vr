using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagesUIManager : MonoBehaviour
{
    [SerializeField] private ChangeScene _changeScene = null;
    [SerializeField] private GameObject _stagesParent = null;
    [SerializeField] private DataManager _data = null;
    StageUI[] _stageUI;
    private void Start()
    {
        _data.SetData(out bool isGameDataExut);
        List<StageSave> stageClearInfo = _data._mySaveData.StageClear;

        _stageUI = _stagesParent.GetComponentsInChildren<StageUI>();
        int id = 0;
        foreach (StageUI s in _stageUI)
        {
            bool isClear = stageClearInfo[id].Isclear;
            if (!isClear)
                s.SetStageUI(this, id++);
            else
            {
                s.SetStageUI(this, id, true, stageClearInfo[id].HP, stageClearInfo[id].UsingTime);
                id++;
            }
        }
    }
    public void ClickBack()
    {
        _changeScene.CallScene(SceneName.Start);
    }
    public void EnterGameScene(int stageNum)
    {
        PlayerPrefs.SetInt("nowPlaying", stageNum);
        PlayerPrefs.Save();
        _changeScene.CallScene(SceneName.Game);
    }
}
