using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienB : MonoBehaviour
{
    private Animator animator;
    private bool readyToAttack;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if (readyToAttack)
            {
                Actor actor = collider.GetComponent<Actor>();
                actor.OnExplode();
            }
            else
            {
                animator.SetInteger("Index", 1); // Attack
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            readyToAttack = false;
            animator.SetInteger("Index", 0); // Idle
        }
    }

    void Attack()
    {
        readyToAttack = true;
    }
}
