using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ConversationModles;

public class GameMainUI : MonoBehaviour
{
    [SerializeField] private ConversationUI _conversationUI = null;
    [SerializeField] private ChangeScene _changeScene = null;
    [SerializeField] private Image _hpBar = null;
    [SerializeField] private Image _douptBar = null;
    [SerializeField] private Image _cardKeyImage = null;
    [SerializeField] private Text _bulletCountText = null;
    [SerializeField] private Text _timerText = null;

    [SerializeField] private GameObject _endPanel = null;
    [SerializeField] private GameObject _overPanel = null;

    [Header("Game clear Panel")]
    [SerializeField] private Text _hpText = null;
    [SerializeField] private Text _timeText = null;
    [SerializeField] private Button _nextButton = null;


    public void SetTimerText(string value) => _timerText.text = value;
    public void GetCardKey() => _cardKeyImage.color = Color.white;
    public void SetHPBar(float value) => _hpBar.fillAmount = value;
    public void SetdouptBar(float value) => _douptBar.fillAmount = value;
    public void SetBulletCount(int cnt) => _bulletCountText.text = cnt.ToString();

    public void ShowEndPanel(string time, float hp)
    {
        _endPanel.SetActive(true);

        _hpText.text = (int)(hp * 100) + "%";
        _timeText.text = time;

        int next = PlayerPrefs.GetInt("nowPlaying", 0) + 1;
        if (next > 4)
            _nextButton.interactable = false;
    }
    public void ShowGameOverPanel()
    {
        _overPanel.SetActive(true);
    }

    public void ClickGoToRestart()
    {
        _changeScene.CallScene(SceneName.Game);
        SoundManager.SM.PlayAudio(SoundName.ButtonClick);
    }
    public void ClickGoToMain()
    {
        _changeScene.CallScene(SceneName.Stage);
        SoundManager.SM.PlayAudio(SoundName.ButtonClick);
    }
    public void ClickGoToNext()
    {
        int next = PlayerPrefs.GetInt("nowPlaying", 0) + 1;
        PlayerPrefs.SetInt("nowPlaying", next);
        PlayerPrefs.Save();
        _changeScene.CallScene(SceneName.Game);
        SoundManager.SM.PlayAudio(SoundName.ButtonClick);
    }
    public void CallConversation(Conversation c)
    {
        _conversationUI.gameObject.SetActive(true);
        _conversationUI.SetConversationUI(c);
    }
    public void EndConversation()
    {
        _conversationUI.gameObject.SetActive(false);
    }
}
