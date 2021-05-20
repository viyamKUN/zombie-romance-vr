using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DataManager _dataManager = null;
    [SerializeField] private GameMainUI _gameMainUI = null;

    [SerializeField] private GameObject[] _stageLevels = null;

    float _hp = 1.0f;
    float _doubt = 0.5f;
    int _bulletCount = 1;
    bool _isHaveCardKey = false;
    float _startTime = 0;

    void Start()
    {
        // Data Setting
        _dataManager.SetData(out bool isGameDataExist);
        if (!isGameDataExist)
            _dataManager.Init();

        _startTime = Time.time;
        int nowStage = PlayerPrefs.GetInt("nowPlaying", 0);
        Instantiate(_stageLevels[nowStage], Vector3.zero, Quaternion.identity);
    }

    void endGame()
    {
        float playTime = Time.time - _startTime;
        _gameMainUI.ShowEndPanel(playTime, _hp);

        // TODO 게임 클리어 정보 전달
        _dataManager.SaveGame();
    }


    ///<summary>Call when get cardkey</summary>
    public void GetCardkey()
    {
        _isHaveCardKey = true;
        _gameMainUI.GetCardKey();
    }

    ///<summary>Call when go into door</summary>
    public void EnterDoor(out bool completeGetIn)
    {
        completeGetIn = _isHaveCardKey;
        if (!_isHaveCardKey)
            return;
        endGame();
    }

    ///<summary>Call when you dead</summary>
    public void Dead()
    {
        _gameMainUI.ShowGameOverPanel();
    }
}
