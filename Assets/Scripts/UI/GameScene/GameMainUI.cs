using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainUI : MonoBehaviour
{
    [SerializeField] private ChangeScene _changeScene = null;
    [SerializeField] private Image _hpBar = null;
    [SerializeField] private Image _douptBar = null;
    [SerializeField] private Image _cardKeyImage = null;
    [SerializeField] private Text _bulletCountText = null;
    [SerializeField] private Text _timerText = null;

    [SerializeField] private GameObject _endPanel = null;
    [SerializeField] private GameObject _overPanel = null;


    public void SetTimerText(string value) => _timerText.text = value;
    public void GetCardKey() => _cardKeyImage.color = Color.white;
    public void SetHPBar(float value) => _hpBar.fillAmount = value;
    public void SetdouptBar(float value) => _douptBar.fillAmount = value;
    public void SetBulletCount(int cnt) => _bulletCountText.text = cnt.ToString();

    public void ShowEndPanel(float time, float hp)
    {
        _endPanel.SetActive(true);
        // 만약 다음 스테이지가 없으면 next는 지우기
    }
    public void ShowGameOverPanel()
    {
        _overPanel.SetActive(true);
    }

    public void ClickGoToRestart()
    {
        _changeScene.CallScene(SceneName.Game);
    }
    public void ClickGoToMain()
    {
        _changeScene.CallScene(SceneName.Stage);
    }
    public void ClickGoToNext()
    {
        PlayerPrefs.SetInt("nowPlaying", PlayerPrefs.GetInt("nowPlaying", 0) + 1);
        PlayerPrefs.Save();
        _changeScene.CallScene(SceneName.Game);
    }
}
