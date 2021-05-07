using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseController : MonoBehaviour
{

    CatController cat;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TurnOn()
    {
        animator.SetBool("isFalling", false);
    }

    public void TurnOff()
    {
        animator.SetBool("isFalling", true);
    }
}
