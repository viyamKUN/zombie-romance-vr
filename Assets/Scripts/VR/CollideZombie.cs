using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideZombie : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Zombie"))
        {
            hit.gameObject.GetComponent<ZombieController>().HitToPlayer();
        }
    }
}
