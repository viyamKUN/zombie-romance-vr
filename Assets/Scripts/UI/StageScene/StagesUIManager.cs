using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagesUIManager : MonoBehaviour
{
    [SerializeField] private ChangeScene _changeScene = null;
    [SerializeField] private GameObject _stagesParent = null;
    StageUI[] _stageUI;
    private void Start()
    {
        _stageUI = _stagesParent.GetComponentsInChildren<StageUI>();
        int id = 0;
        foreach (StageUI s in _stageUI)
        {
            s.SetStageUI(this, id++); // give Save Data
            // TODO
            // Blocked unlock stages
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
