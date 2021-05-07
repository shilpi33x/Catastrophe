using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSpeed : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.speed = 1f;
    }
}
