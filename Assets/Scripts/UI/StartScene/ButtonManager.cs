using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private ChangeScene _changeScene = null;
    [SerializeField] private DataManager _dataManager = null;
    [SerializeField] private Button _resetButton = null;
    [SerializeField] private Text _nameText = null;

    [Header("User Data Panel")]
    [SerializeField] private GameObject _userDataInputPanel = null;
    [SerializeField] private InputField _nameInput = null;
    [SerializeField] private Button _nameEnterButton = null;

    private void Start()
    {
        _dataManager.SetData(out bool isGameDataExist);
        _resetButton.interactable = isGameDataExist;
        if (!isGameDataExist)
        {
            _userDataInputPanel.SetActive(true);
            return;
        }
        _nameText.text = _dataManager.UserName;
    }
    public void ClickQuit()
    {
        Application.Quit();
    }
    public void ClickOption()
    {
        Debug.Log("Option");
    }
    public void ClickReset()
    {
        _dataManager.DeleteGame();
        _changeScene.CallScene(SceneName.Start);
    }
    public void ClickStart()
    {
        _changeScene.CallScene(SceneName.Stage);
    }
    public void ClickUserInputComplete()
    {
        _dataManager.Init();
        _resetButton.interactable = true;
        _dataManager.UserName = _nameInput.text;
        _nameText.text = _dataManager.UserName;
        _dataManager.SaveGame();
        _userDataInputPanel.SetActive(false);
    }
}
