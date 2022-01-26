using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private Animator animator;
    private DoorTrigger doorTrigger;

    void Start()
    {
        animator = GetComponent<Animator>();
        doorTrigger = GetComponent<DoorTrigger>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (animator != null)
        {
            animator.SetInteger("Index", 1); // Down
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (doorTrigger != null && doorTrigger.sticky)
        {
            return;
        }

        if (animator != null)
        {
            animator.SetInteger("Index", 2); // Up
        }
    }
}
