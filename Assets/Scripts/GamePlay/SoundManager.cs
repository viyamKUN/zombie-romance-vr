using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundName
{

}
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _myAudio = null;
    [SerializeField] private AudioClip[] _audios = null;
    public static SoundManager SM = null;
    private void Awake()
    {
        SM = this;
    }
    public void PlayAudio(SoundName s)
    {
        _myAudio.PlayOneShot(_audios[(int)s]);
    }
}
