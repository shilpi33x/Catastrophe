using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockVase : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<VaseController>().TurnOff();
    }
}
