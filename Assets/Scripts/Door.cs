using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    private new Collider2D collider2D;

    public enum DoorState { Idle, Opening, Open, Closing }
    public DoorState state = DoorState.Idle;
    public float closeDelay = 0.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
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
        collider2D.enabled = true;
    }

    void DisableCollider2D()
    {
        collider2D.enabled = false;
    }

    IEnumerator CloseNow()
    {
        yield return new WaitForSeconds(closeDelay);
        animator.SetInteger("Index", 2);
    }

    public void Open()
    {
        animator.SetInteger("Index", 1);
    }

    public void Close()
    {
        StartCoroutine(CloseNow());
    }
}
