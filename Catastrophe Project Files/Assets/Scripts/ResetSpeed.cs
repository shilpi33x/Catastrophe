using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSpeed : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.speed = 1f;
    }
}
