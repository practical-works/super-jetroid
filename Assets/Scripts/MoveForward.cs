using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;

public class MoveForward : MonoBehaviour
{
    public float speedX = 0.5f;

    private new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        int direction = transform.localScale.x > 0 ? 1 : -1;
        rigidbody2D.velocity = new Vector2((float)direction, 0) * speedX;
    }
}
