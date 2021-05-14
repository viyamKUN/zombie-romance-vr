using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{
    [SerializeField] private GameObject _clearStamp = null;
    [SerializeField] private Text _remainHPtext = null;
    [SerializeField] private Text _playTime = null;
    StagesUIManager _uiManager = null;
    int thisStageID = 0;
    public void SetStageUI(StagesUIManager uiManager, int id, bool isClear = false, int hp = 0, float time = 0)
    {
        this._uiManager = uiManager;
        this.thisStageID = id;
        if (!isClear)
        {
            this._clearStamp.SetActive(false);
            this._remainHPtext.text = "";
            this._playTime.text = "";
            return;
        }
        this._clearStamp.SetActive(true);
        this._remainHPtext.text = hp.ToString();
        this._playTime.text = time.ToString();
    }

    public void ClickStage()
    {
        _uiManager.EnterGameScene(thisStageID);
    }
}
