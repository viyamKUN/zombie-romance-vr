using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieStatus
{
    Idle, Walking, Talk, Attack, Dead
}
public enum AudioName
{
    Idle, Walking, Die, Attack
}
public class ZombieController : MonoBehaviour
{
    [Header("음악")]
    [SerializeField] private AudioSource _loopingAudio = null;
    [SerializeField] private AudioSource _audio = null;
    [SerializeField] private AudioClip[] _clips = null;
    Coroutine playAudioCoro = null;
    AudioName currentAudio = AudioName.Idle;
    [Header("비주얼")]
    [SerializeField] private Animator _zombieAnim = null;
    [SerializeField] private float _speed = 1;
    ZombieStatus _myStatus = ZombieStatus.Idle;
    Transform _playerTransform = null;
    Vector3 _move = Vector3.zero;
    bool isAlive = true;

    private void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        if (GameManager.GM.Doupt >= 1.0)
        {
            if (_myStatus.Equals(ZombieStatus.Attack)) return;

            float xDis = _playerTransform.position.x - this.transform.position.x;
            float zDis = _playerTransform.position.z - this.transform.position.z;

            if (Mathf.Abs(xDis) > 1f || Mathf.Abs(zDis) > 1f)
            {
                this.transform.LookAt(_playerTransform);

                _move = new Vector3(xDis, 0, zDis).normalized * Time.fixedDeltaTime * _speed * 0.1f;
                this.transform.position += _move;

                _zombieAnim.SetBool("isWalk", true);
                _myStatus = ZombieStatus.Walking;
                changeLoopingAudio(AudioName.Walking);
            }
            else
            {
                _zombieAnim.SetBool("isWalk", false);
                _myStatus = ZombieStatus.Idle;
                changeLoopingAudio(AudioName.Idle);
                attackPlayer();
            }
        }
    }
    public void Hit()
    {
        _zombieAnim.SetTrigger("Die");
        _myStatus = ZombieStatus.Dead;
        isAlive = false;
        _loopingAudio.Stop();
        _audio.PlayOneShot(_clips[(int)AudioName.Die]);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (!isAlive) return;
        if (other.gameObject.CompareTag("Bullet"))
        {
            this.Hit();
            GameManager.GM.Doupt += 0.2f;
        }
    }
    public void HitToPlayer()
    {
        if (!isAlive) return;
        _zombieAnim.SetBool("isWalk", false);
        if (GameManager.GM.Doupt >= 1.0)
        {
            if (_myStatus.Equals(ZombieStatus.Attack)) return;
            attackPlayer();
        }
        else
        {
            if (_myStatus.Equals(ZombieStatus.Talk)) return;
            talkToPlayer();
        }
    }
    public void EndConversation()
    {
        _myStatus = ZombieStatus.Idle;
    }
    public void EndAttackMotion()
    {
        _myStatus = ZombieStatus.Idle;
    }
    private void attackPlayer()
    {
        _zombieAnim.SetTrigger("attack");
        _myStatus = ZombieStatus.Attack;
        GameManager.GM.HP -= 0.1f;
        playAudioOnce(AudioName.Attack);
    }

    private void talkToPlayer()
    {
        Debug.Log("Hello???");
        _myStatus = ZombieStatus.Talk;
        GameManager.GM.CallConversation(this);
    }
    private void changeLoopingAudio(AudioName a)
    {
        if (currentAudio.Equals(a)) return;
        currentAudio = a;
        _loopingAudio.Stop();
        _loopingAudio.clip = _clips[(int)a];
        _loopingAudio.Play();
    }
    private void playAudioOnce(AudioName a)
    {
        if (playAudioCoro != null)
        {
            StopCoroutine(playAudioCoro);
            playAudioCoro = null;
        }
        playAudioCoro = StartCoroutine(playAudio(a));
    }
    IEnumerator playAudio(AudioName a)
    {
        _loopingAudio.Pause();
        _audio.PlayOneShot(_clips[(int)a]);

        yield return new WaitForSeconds(3f);

        _loopingAudio.Play();
    }

}
