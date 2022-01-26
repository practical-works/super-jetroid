using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    private bool onAir = false;

    public Vector2 speed = new Vector2(20, 15);
    public Vector2 maxVelocity = new Vector2(2, 3);
    public float airSpeedXCoeff = 0.1f;
    public BodyPart bodyPart;
    public int bodyPartsCount = 5;

    void Update()
    {
        ActorCtrl controller = GetComponent<ActorCtrl>();
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        Vector2 absVelocity = new Vector2(Mathf.Abs(rigidbody2D.velocity.x), Mathf.Abs(rigidbody2D.velocity.y));
        Animator animator = GetComponent<Animator>();

        onAir = (absVelocity.y != 0);

        if (controller.direction.x != 0)
        {
            if (absVelocity.x < maxVelocity.x)
            {
                float speedXCoeff = onAir ? airSpeedXCoeff : 1;
                float xForce = controller.direction.x * speed.x * speedXCoeff;
                rigidbody2D.AddForce(new Vector2(xForce, 0));
                GetComponent<SpriteRenderer>().flipX = (controller.direction.x < 0);
                animator.SetInteger("Index", 1); // Walk
            }
        }
        else if (!onAir)
        {
            animator.SetInteger("Index", 0); // Idle
        }

        if (controller.direction.y != 0)
        {
            if (absVelocity.y < maxVelocity.y)
            {
                float yForce = controller.direction.y * speed.y;
                rigidbody2D.AddForce(new Vector2(0, yForce));
                animator.SetInteger("Index", 2); // Jet
            }
        }
        else if (onAir)
        {
            animator.SetInteger("Index", 3); // Jet-Empty
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Deadly")
        {
            OnExplode();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Deadly")
        {
            OnExplode();
        }
    }

    public void OnExplode()
    {
        Destroy(gameObject);

        for (int i = 0; i < bodyPartsCount; i++)
        {
            BodyPart bodyPartClone = Instantiate(bodyPart, transform.position, Quaternion.identity);
            Rigidbody2D rigidbody = bodyPartClone.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(new Vector2(Random.Range(-50, 50), Random.Range(100, 400)));
        }
    }
}
