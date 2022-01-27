using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;

public class AutoMover : MonoBehaviour
{
    public float speedX = 0.5f;

    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        int direction = transform.localScale.x > 0 ? 1 : -1;
        _rigidbody2D.velocity = new Vector2((float)direction, 0) * speedX;
    }
}
