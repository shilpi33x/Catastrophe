using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionText : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject, delay);
        }
    }
}
