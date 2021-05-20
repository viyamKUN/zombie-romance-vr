using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private Animator _zombieAnim = null;

    public void Hit()
    {
        _zombieAnim.SetTrigger("Die");
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Detected Collision");
        if (other.gameObject.CompareTag("Player"))
        {
            _zombieAnim.SetTrigger("attack");
            GameManager.GM.HP -= 0.1f;
        }
    }
}
