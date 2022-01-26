using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienC : MonoBehaviour
{
    public float attackDelay = 3f;
    public Projectile projectile;

    private Animator animator;
    private float _elapsedTime = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (attackDelay > 0)
        {
            StartCoroutine(OnAttack());
        }
    }

    void Update()
    {
        animator.SetInteger("Index", 0); // Idle
        _elapsedTime += Time.deltaTime;
    }

    IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        animator.SetInteger("Index", 1); // Attack
        StartCoroutine(OnAttack());
        print(_elapsedTime + " seconds");
    }

    void OnShoot()
    {
        if (projectile != null)
        {
            Projectile newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }
}
