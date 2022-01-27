using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum DoorState { Idle, Opening, Open, Closing }
    public DoorState state = DoorState.Idle;
    public float closeDelay = 0.5f;

    private Animator _animator;
    private Collider2D _collider2D;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();
    }

    void OnOpenStart()
    {
        state = DoorState.Opening;
    }

    void OnOpenEnd()
    {
        state = DoorState.Opening;
    }

    void OnCloseStart()
    {
        state = DoorState.Closing;
    }

    void OnCloseEnd()
    {
        state = DoorState.Idle;
    }

    void EnableCollider2D()
    {
        _collider2D.enabled = true;
    }

    void DisableCollider2D()
    {
        _collider2D.enabled = false;
    }

    public void Open()
    {
        _animator.SetInteger("Index", 1); // Open
    }

    public void Close()
    {
        StartCoroutine(CloseAfterDelay());
    }

    IEnumerator CloseAfterDelay()
    {
        yield return new WaitForSeconds(closeDelay);
        _animator.SetInteger("Index", 2); // Closed
    }
}
