using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DataManager _dataManager = null;


    void Start()
    {
        // Data Setting
        _dataManager.SetData(out bool isGameDataExist);
        if (!isGameDataExist)
            _dataManager.Init();
    }

    void endGame()
    {
        // TODO 게임 클리어 정보 전달
        _dataManager.SaveGame();
    }
}
