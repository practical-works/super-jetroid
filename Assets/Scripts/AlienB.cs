using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienB : MonoBehaviour
{
    public AudioClip attackSound;

    private Animator _animator;
    private bool _readyToAttack;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if (_readyToAttack)
            {
                collider.GetComponent<Exploder>().Explode();
            }
            else
            {
                _animator.SetInteger("Index", 1); // Attack
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if (!_readyToAttack)
            {
                AudioSource.PlayClipAtPoint(attackSound, transform.position);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            _readyToAttack = false;
            _animator.SetInteger("Index", 0); // Idle
        }
    }

    void Attack()
    {
        _readyToAttack = true;
    }
}
