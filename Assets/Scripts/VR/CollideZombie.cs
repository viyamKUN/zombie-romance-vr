using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideZombie : MonoBehaviour
{
    [SerializeField] private ZombieController zombie;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Zombie"))
        {
            zombie.attackPlayer();
        }
    }
    
}
