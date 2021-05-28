using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAttackAnimation : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<ZombieController>().EndAttackMotion();
    }
}
