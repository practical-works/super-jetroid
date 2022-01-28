using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public Vector2 speed = new Vector2(10f, 15f);
    public Vector2 maxVelocity = new Vector2(3f, 2f);
    public float airSpeedXCoeff = 0.1f;
    public AudioClip rightFootSound;
    public AudioClip leftFootSound;
    public AudioClip thudSound;
    public AudioClip rocketSound;

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
        Vector2 absVelocity = new Vector2(
            Mathf.Abs(_rigidbody2D.velocity.x),
            Mathf.Abs(_rigidbody2D.velocity.y)
        );
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
            PlayRocketSound();
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
        if (collider.tag == "Deadly")
        {
            _exploder.Explode();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 absVelocity = new Vector2(
            Mathf.Abs(_rigidbody2D.velocity.x),
            Mathf.Abs(_rigidbody2D.velocity.y)
        );

        if (absVelocity.x == 0 || absVelocity.y == 0)
        {
            PlayThudFootSound();
        }

        if (collision.collider.tag == "Deadly")
        {
            _exploder.Explode();
        }
    }

    void PlayRightFootSound()
    {
        AudioSource.PlayClipAtPoint(rightFootSound, transform.position);
    }

    void PlayLeftFootSound()
    {
        AudioSource.PlayClipAtPoint(leftFootSound, transform.position);
    }

    void PlayThudFootSound()
    {
        AudioSource.PlayClipAtPoint(thudSound, transform.position);
    }

    void PlayRocketSound()
    {
        if (!GameObject.Find("RocketSoundPlayback"))
        {
            GameObject gameObj = new GameObject("RocketSoundPlayback");
            AudioSource audioSrc = gameObj.AddComponent<AudioSource>();
            audioSrc.clip = rocketSound;
            audioSrc.volume = 0.1f;
            audioSrc.Play();
            Destroy(gameObj, audioSrc.clip.length);
        }
    }
}
