﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 15);
    public Vector2 maxVelocity = new Vector2(3, 2);
    public float airSpeedXCoeff = 0.1f;

    private bool _onAir;
    private Controller _controller;
    private Exploder _exploder;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    void Start()
    {
        _controller = GetComponent<Controller>();
        _exploder = GetComponent<Exploder>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 absVelocity = new Vector2(Mathf.Abs(_rigidbody2D.velocity.x), Mathf.Abs(_rigidbody2D.velocity.y));
        _onAir = (absVelocity.y != 0);

        if (_controller.direction.x != 0)
        {
            if (absVelocity.x < maxVelocity.x)
            {
                float speedXCoeff = _onAir ? airSpeedXCoeff : 1;
                float xForce = _controller.direction.x * speed.x * speedXCoeff;
                _rigidbody2D.AddForce(new Vector2(xForce, 0));
                GetComponent<SpriteRenderer>().flipX = (_controller.direction.x < 0);
                _animator.SetInteger("Index", 1); // Walk
            }
        }
        else if (!_onAir)
        {
            _animator.SetInteger("Index", 0); // Idle
        }

        if (_controller.direction.y != 0)
        {
            if (absVelocity.y < maxVelocity.y)
            {
                float yForce = _controller.direction.y * speed.y;
                _rigidbody2D.AddForce(new Vector2(0, yForce));
                _animator.SetInteger("Index", 2); // Jet
            }
        }
        else if (_onAir)
        {
            _animator.SetInteger("Index", 3); // Jet-Empty
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (_exploder == null)
        {
            Error.MissingComponent(this, typeof(Exploder));
            return;
        }

        if (collider.tag == "Deadly")
        {
            _exploder.Explode();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_exploder == null)
        {
            Error.MissingComponent(this, typeof(Exploder));
            return;
        }

        if (collision.collider.tag == "Deadly")
        {
            _exploder.Explode();
        }
    }
}
