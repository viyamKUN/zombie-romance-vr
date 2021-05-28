using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieStatus
{
    Idle, Walking, Talk, Attack, Dead
}
public class ZombieController : MonoBehaviour
{
    [SerializeField] private Animator _zombieAnim = null;
    ZombieStatus _myStatus = ZombieStatus.Idle;

    public void Hit()
    {
        _zombieAnim.SetTrigger("Die");
        _myStatus = ZombieStatus.Dead;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            this.Hit();
            GameManager.GM.Doupt += 0.2f;
        }
    }
    public void HitToPlayer()
    {
        if (GameManager.GM.Doupt >= 1.0)
        {
            if (_myStatus.Equals(ZombieStatus.Talk)) return;
            if (_myStatus.Equals(ZombieStatus.Attack)) return;
            attackPlayer();
            _myStatus = ZombieStatus.Attack;
        }
        else
        {
            if (_myStatus.Equals(ZombieStatus.Talk)) return;
            talkToPlayer();
            _myStatus = ZombieStatus.Talk;
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
        GameManager.GM.HP -= 0.1f;
    }


    Coroutine tempCoro = null;
    private void talkToPlayer()
    {
        Debug.Log("Hello???");
        GameManager.GM.Doupt += 0.1f;
        if (tempCoro != null)
            StopCoroutine(tempCoro);
        tempCoro = StartCoroutine(tempTalkWaiting());
    }
    IEnumerator tempTalkWaiting()
    {
        yield return new WaitForSeconds(2.0f);
        EndConversation();
    }
}
