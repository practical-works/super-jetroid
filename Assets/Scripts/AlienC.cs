using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienC : MonoBehaviour
{
    public float attackDelay = 3f;
    public Projectile projectile;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        if (attackDelay > 0)
        {
            StartCoroutine(Attack());
        }
    }

    void Update()
    {
        _animator.SetInteger("Index", 0); // Idle
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackDelay);
        _animator.SetInteger("Index", 1); // Attack
        StartCoroutine(Attack());
    }

    void CreateProjectile()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
