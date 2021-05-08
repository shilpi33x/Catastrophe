﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterSpecialAnimation : StateMachineBehaviour
{

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<CatController>().CallReachFunction();
    }
}
