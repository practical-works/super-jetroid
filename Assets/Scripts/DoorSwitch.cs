using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public AudioClip switchSound;

    private DoorTrigger _doorTrigger;
    private Animator _animator;

    void Start()
    {
        _doorTrigger = GetComponent<DoorTrigger>();
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        _animator.SetInteger("Index", 1); // Down
        AudioSource.PlayClipAtPoint(switchSound, transform.position);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (_doorTrigger.sticky)
        {
            return;
        }

        _animator.SetInteger("Index", 2); // Up
        AudioSource.PlayClipAtPoint(switchSound, transform.position);
    }
}
