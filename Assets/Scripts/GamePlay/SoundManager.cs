using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundName
{
    ButtonClick, ButtonHover, CardReader, ConversationEvent, DoorOpen, FootStep, GameClear, GameOver, GetItem, GrabItem, PlayerHit
}
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _myAudio = null;
    [SerializeField] private AudioSource _bgmAudio = null;
    [SerializeField] private AudioClip[] _audios = null;
    [SerializeField] private AudioClip[] _bgms = null;
    public static SoundManager SM = null;
    private void Awake()
    {
        SM = this;
    }
    public void PlayAudio(SoundName s)
    {
        _myAudio.PlayOneShot(_audios[(int)s]);
    }
    public void ChangeBGM()
    {
        _bgmAudio.clip = _bgms[1];
    }
}
