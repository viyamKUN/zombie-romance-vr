using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainUI : MonoBehaviour
{
    [SerializeField] private Image _hpBar = null;
    [SerializeField] private Image _douptBar = null;
    [SerializeField] private Image _cardKeyImage = null;
    [SerializeField] private Text _bulletCountText = null;


    public void GetCardKey() => _cardKeyImage.color = Color.white;
    public void SetHPBar(float value) => _hpBar.fillAmount = value;
    public void SetdouptBar(float value) => _douptBar.fillAmount = value;
    public void SetBulletCount(int cnt) => _bulletCountText.text = cnt.ToString();
}
